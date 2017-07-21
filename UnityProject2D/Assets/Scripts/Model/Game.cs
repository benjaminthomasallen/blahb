using UnityEngine;
using System.Collections;

namespace Blahb
{
	public class Game
	{
		#region Notifications
		public const string DidBeginGameNotification = "Game.DidBeginGameNotification";
		public const string DidMovePieceNotification = "Game.DidMovePieceNotification";
		public const string DidChangeControlNotification = "Game.DidChangeControlNotification";
		public const string DidEndGameNotification = "Game.DidEndGameNotification";
		#endregion

		#region Constructor
		public Game ()
		{

		}
		#endregion

		#region Private
		void ChangeTurn ()
		{
			// code to actually change turn
			this.PostNotification(DidChangeControlNotification);
		}

		#endregion
	}
}
