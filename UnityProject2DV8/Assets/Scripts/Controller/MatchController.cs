using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatchController : MonoBehaviour 
{

	#region Notifications
	public const string MatchReady = "MatchController.Ready";
	#endregion

	#region Fields & Properties
	public bool IsReady { get { return localPlayer != null && remotePlayer != null; }}
	public PlayerController localPlayer;
	public PlayerController remotePlayer;
	public PlayerController hostPlayer;
	public PlayerController clientPlayer;
	public List<PlayerController> players = new List<PlayerController>();
	#endregion

	#region MonoBehaviour
	void OnEnable()
	{
		this.AddObserver(OnPlayerStarted, PlayerController.Started);
		this.AddObserver(OnPlayerStartedLocal, PlayerController.StartedLocal);
		this.AddObserver(OnPlayerDestroyed, PlayerController.Destroyed);
	}

	void OnDisable()
	{
		this.RemoveObserver(OnPlayerStarted, PlayerController.Started);
		this.RemoveObserver(OnPlayerStartedLocal, PlayerController.StartedLocal);
		this.RemoveObserver(OnPlayerDestroyed, PlayerController.Destroyed);
	}
	#endregion

	#region EventHandlers
	void OnPlayerStarted(object sender, object args)
	{
		players.Add((PlayerController)sender);
		Configure();
	}

	void OnPlayerStartedLocal(object sender, object args)
	{
		localPlayer = (PlayerController)sender;
		Configure();
	}

	void OnPlayerDestroyed(object sender, object args)
	{
		PlayerController pc = (PlayerController)sender;

		if (localPlayer == pc)
			localPlayer = null;

		if (remotePlayer == pc)
			remotePlayer = null;

		if (hostPlayer == pc)
			hostPlayer = null;

		if (clientPlayer == pc)
			clientPlayer = null;

		if (players.Contains(pc))
			players.Remove(pc);
	}

	void Configure()
	{
		if (localPlayer == null || players.Count != 2)
			return;

		for (int i = 0; i < players.Count; i++) 
		{
			if (players [i] != localPlayer) 
			{
				remotePlayer = players [i];
				break;
			}
		}
		
		hostPlayer = (localPlayer.isServer) ? localPlayer : remotePlayer;
		clientPlayer = (localPlayer.isServer) ? remotePlayer : localPlayer;
		
		this.PostNotification (MatchReady);
	}
	#endregion
}
