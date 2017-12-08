using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Game over controller handles player interaction and displays the final result of the game.
/// </summary>
public class GameOverController : MonoBehaviour 
{
	/// <summary>
	/// The score of the game.
	/// </summary>
	//Score result
	public Text Score;

	// Use this for initialization
	void Start () {
		ScoreFunction ();
	}

	/// <summary>
	/// Adding a value to a variable.
	/// </summary>
	public void ScoreFunction()
	{
		Score.text = PlayerPrefs.GetInt ("Score").ToString();
	}

	/// <summary>
	/// Restart the game scene.
	/// </summary>
	public void Replay()
	{
		//GameScene
		SceneManager.LoadScene (1);
	}

	/// <summary>
	/// Start the main scene.
	/// </summary>
	public void Quit()
	{
		//MainMenu
		SceneManager.LoadScene (0);
	}
}
