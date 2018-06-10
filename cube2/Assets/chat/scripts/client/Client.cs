using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Client : MonoBehaviour 
{
	public GameObject chatContainer;
	public GameObject messagePrefab;

	public  string clientName;

	private bool socketReady; 
	private TcpClient socket;
	private StreamWriter writer;
	private StreamReader reader;
	private NetworkStream stream;


	public void ConnectToServer()
	{
		if (socketReady)
			return;

		string host = "127.0.0.1";
		int port = 6321;
		string h;
		int p;
		 
		h = GameObject.Find ("InputIP").GetComponent<InputField> ().text;
		if (h != "")
			host = h;
		int.TryParse (GameObject.Find ("InputPort").GetComponent<InputField> ().text, out p);
		if (p != 0)
			port = p;

		//string clname = GameObject.Find ("InputName").GetComponent<InputField> ().text;
		//clientName = clname;
		clientName = "Server";
		Debug.Log (clientName);

		//////cкрываем панель LOGIN
		GameObject login = GameObject.Find ("Login") as GameObject;
		login.SetActive (false);

		GameObject panel2 = GameObject.Find ("Panel2") as GameObject;
		panel2.SetActive (false);


		try
		{
			socket = new TcpClient(host, port);
			stream = socket.GetStream();
			writer = new StreamWriter(stream);
			reader = new StreamReader(stream);
			socketReady = true;
		}
		catch(Exception e) 
		{
			Debug.Log ("socket error: " + e.Message);
		}
	}

	private void Update()
	{
		if (socketReady) {
			if (stream.DataAvailable) {
				string data = reader.ReadLine ();
				if (data != null)
					OnIncomingData (data);
			}
		}
	}

	private void OnIncomingData(string data)/// пишет имя и текст в контейнеры
	{
		if (data == "%NAME") {
		
			Send ("&NAME|" + clientName);
			return;
		}

		//Debug.Log ("server : "+ data);
		GameObject go = Instantiate(messagePrefab, chatContainer.transform) as GameObject;
		go.GetComponentInChildren<Text> ().text = data; 
	}

	private void Send(string data){//пишет данные
	
		if (!socketReady)
			return;

		writer.WriteLine (data);
		writer.Flush ();

	}

	public void OnSendButton()//событие кнопки отправки смс
	{
		string message = GameObject.Find ("InputSend").GetComponent<InputField> ().text;
		Send (message);
		message = "";
		Debug.Log(message);
	}

	public void Exit()//событие кнопки "выход"
	{
		Application.LoadLevel("menu");
		Debug.Log ("Exit chat");
	}

	private void CloseSocket()
	{
		if (!socketReady)
			return;

		writer.Close ();
		reader.Close ();
		socket.Close ();
		socketReady = false;
	}

	private void OnApplicationQuit()
	{
		CloseSocket ();
	}

	private void OnDisable()
	{
		CloseSocket ();
	}


}
