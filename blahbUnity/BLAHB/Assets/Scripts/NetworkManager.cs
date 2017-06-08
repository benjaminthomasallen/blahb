using UnityEngine;
using System.Collections;
using System;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}

	private const string roomName = "RoomName";
	private RoomInfo[] roomsList;

	void OnGUI()
	{
		if (!PhotonNetwork.connected)
		{
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		}
		else if (PhotonNetwork.room == null)
		{
			// Create Room
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				PhotonNetwork.CreateRoom(roomName + Guid.NewGuid().ToString("N"), new RoomOptions() { maxPlayers = 2}, null);

			// Join Room
			if (roomsList != null)
			{
				for (int i = 0; i < roomsList.GetLength(0); i++)
				{
					if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].Name))
						PhotonNetwork.JoinRoom(roomsList[i].Name);
				}
			}
		}
	}

	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();
	}
	void OnJoinedRoom()
	{
		Debug.Log("Connected to Room");
	}
		
	/*
	// Update is called once per frame
	void Update () {
		
	}*/
}
