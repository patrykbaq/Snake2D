using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all elements in this game.
/// </summary>
public class GameElement : MonoBehaviour
{
	// Gives access to the game and all instances.
	public Game Game {get {return Game.GetInstance(); }}
}

/// <summary>
/// Class that handles the Snake Game.
/// </summary>
public sealed class Game : MonoBehaviour 
{
	// Singleton
	private static Game instance;
	public static Game GetInstance()
	{
		if (instance == null)
			instance = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();

		return instance;
	}

	// Reference to the root instances of the MVC.
	public GameModel Model;
	public GameView View;
	public GameController Controller;
}
