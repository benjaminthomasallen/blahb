using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Blahb;


public class PlayerController : NetworkBehaviour {

	#region Notifications
	public const string Started = "PlayerController.Start";
	public const string StartedLocal = "PlayerController.StartedLocal";
	public const string Destroyed = "PlayerController.Destroyed";
	public const string CoinToss = "PlayerController.CoinToss";
	//public const string RequestMarkSquare = "PlayerController.RequestMarkSquare";
	#endregion

	#region NetworkBehaviour
	public override void OnStartClient()
	{
		base.OnStartClient ();
		this.PostNotification(Started);
	}

	public override void OnStartLocalPlayer()
	{
		base.OnStartLocalPlayer ();
		this.PostNotification(StartedLocal);
	}

	// to post notification when player leaves
	void OnDestroy()
	{
		this.PostNotification(Destroyed);
	}
	#endregion

	#region Networking
	[Command]
	public void CmdCoinToss()
	{
		RpcCoinToss(Random.value < 0.5);
	}

	[ClientRpc]
	void RpcMoveToken(bool coinToss)
	{
		this.PostNotification(coinToss, coinToss);
	}
	#endregion

}
