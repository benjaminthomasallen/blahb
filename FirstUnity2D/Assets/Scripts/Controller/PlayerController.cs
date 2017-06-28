using UnityEngine;
using UnityEngine.Networking;
using System.Collections;



public class PlayerController : NetworkBehaviour {

	public const string Started = "PlayerController.Start";
	public const string StartedLocal = "PlayerController.StartedLocal";
	public const string Destroyed = "PlayerController.Destroyed";
	public const string CoinToss = "PlayerController.CoinToss";
	//public const string RequestMarkSquare = "PlayerController.RequestMarkSquare";

	public override void OnStartClient()
	{
		base.OnStartClient ();
		this.PostNotification (Started);
	}

	public override void OnStartLocalPlayer()
	{
		base.OnStartLocalPlayer ();
		this.PostNotification (StartedLocal);
	}

	// to post notification when player leaves
	void OnDestroy()
	{
		this.PostNotification (Destroyed);
	}

	[Command]
	public void CmdCoinToss()
	{
		RpcCoinToss (Random.value < 0.5);
	}

	[ClientRpc]
	void RpcMoveToken(bool coinToss)
	{
		this.PostNotification (coinToss, coinToss);
	}

}
