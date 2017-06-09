using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour 
{

	public void OnStartGameButton()
	{
		SceneManager.LoadScene ("GridScene");
	}

	public void OnCreditsButton()
	{
		SceneManager.LoadScene ("Credits");
	}

	public void OnQuitButton()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit ();

	}
		
}
