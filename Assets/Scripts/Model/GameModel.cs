using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Class that handles the game date.
/// </summary>
public class GameModel : GameElement
{
	/// <summary>
	/// The speed snake in ms.
	/// </summary>
	public float SpeedSnake;

	/// <summary>
	/// Keep Track of Tail.
	/// </summary>
	public List<Transform> Tail = new List<Transform>();

	/// <summary>
	/// The current direction of head.
	/// </summary>
	private int currentDirection;
	public int CurrentDirection { get; set; }

	/// <summary>
	/// The next position of head.
	/// </summary>
	private Vector2 nextPosition;
	public Vector2 NextPosition { get; set; }

	/// <summary>
	/// Initial the size tail of Snake.
	/// </summary>
	private int sizeTail;
	public int SizeTail { get; set; }

	/// <summary>
	/// The score of the game.
	/// </summary>
	private int score;
	public int Score { get; set; }

	/// <summary>
	/// The width the game.
	/// </summary>
	private int width;
	public int Width
	{
		get { return width; }
		set { width = value; }
	}

	/// <summary>
	/// The height the game.
	/// </summary>
	private int height;
	public int Height
	{
		get { return height; }
		set { height = value; }
	}
}
