﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System;
using UnityEngine.UI;

public class Server : MonoBehaviour 
{
	private List<ServerClient> clients;
	private List<ServerClient> disconnectList;

	public int port = 6321;
	private TcpListener server;
	bool serverStarted;

	 

	private void Start() //старат сервера
	{
		clients = new List<ServerClient>();//список подключенных клиентов
		disconnectList = new List<ServerClient>();//список отключенных клиентов
		try
		{
			server= new TcpListener(IPAddress.Any, port);
			server.Start();
			serverStarted = true;
			Debug.Log("server started on port " + port.ToString());

			StartListening();

		}

		catch(Exception e)
		{
			Debug.Log ("server error: " + e.Message);
		}
	}

	private void Update()
	{
		
		if (!serverStarted) {
			return;
		}
		foreach (ServerClient c in clients) {
			if (!IsConnected (c.tcp)) {
				c.tcp.Close ();
				disconnectList.Add (c);
				continue;
			} else {
				NetworkStream s = c.tcp.GetStream ();
				if (s.DataAvailable) {
					StreamReader reader = new StreamReader (s, true);
				
					string data = reader.ReadLine ();

					if (data != null)
						OnIncomingData (c, data);
				}
			}
		}

		for (int i = 0; i < disconnectList.Count - 1; i++) 
		{
			Broadcast (disconnectList[i].clientName + " отключен ",clients);

			clients.Remove (disconnectList[i]);
			disconnectList.RemoveAt(i);
		}
	}

	private bool IsConnected(TcpClient c)
	{
		try{
			if(c != null && c.Client != null && c.Client.Connected)
			{
				if(c.Client.Poll(0, SelectMode.SelectRead))
				{
					return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);
				}
				return true;
			}else 
				return false;
	}
		catch
		{
			return false;
		}
	}

	private void StartListening()
	{
		server.BeginAcceptTcpClient (AcceptTcpClient, server);
	}

	private void AcceptTcpClient(IAsyncResult ar)
	{
		TcpListener listener = (TcpListener)ar.AsyncState;

		clients.Add (new ServerClient (listener.EndAcceptTcpClient (ar)));
		StartListening();
		Broadcast ("%NAME", new List<ServerClient>(){clients[clients.Count-1]});
		//Broadcast (clients[clients.Count-1].clientName , clients);
	}

	private void OnIncomingData(ServerClient c, string data)
	{
		if(data.Contains("&NAME"))
			{
				c.clientName = data.Split('|')[1];
				Broadcast(c.clientName + " подключен", clients);
				return;
			}
		Debug.Log (c.clientName + "has sent the following message: " + data);
		Broadcast(c.clientName + " : " + data,clients);
	}

	private void Broadcast(string data, List<ServerClient> cl)
	{
		foreach(ServerClient c in cl){
			try
			{
				StreamWriter writer = new StreamWriter(c.tcp.GetStream());
				writer.WriteLine(data);
				writer.Flush();
			}
			catch(Exception e)
			{
				Debug.Log("write error: "+ e.Message+ "to client" + c.clientName);
			}
	}

}

public class ServerClient
{
	public TcpClient tcp;
	public string clientName;

	public ServerClient(TcpClient clientSocket)
		{	
			clientName = "Guest";
			
		tcp = clientSocket;
	}



}
}
