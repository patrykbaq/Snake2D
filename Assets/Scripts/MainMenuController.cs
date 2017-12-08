using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main menu controller handles player interaction.
/// </summary>
public class MainMenuController : MonoBehaviour 
{
	/// <summary>
	/// Start the game scene.
	/// </summary>
	public void Play()
	{
		//GameScene
		SceneManager.LoadScene(1);
	}

	/// <summary>
	/// Exit this game.
	/// </summary>
	public void Exit()
	{
		Application.Quit ();
	}
}
