using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatchController : MonoBehaviour {

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
	void OnPlayerStarted (object sender, object args)
	{
		players.Add((PlayerController)sender);
		Configure();
	}

	#endregion
}
