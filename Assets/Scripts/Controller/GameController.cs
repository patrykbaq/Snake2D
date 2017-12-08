using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

/// <summary>
/// Game controller handles events from the game and player interaction.
/// </summary>
public class GameController : GameElement
{
	/// <summary>
	/// Did snake eat something?
	/// </summary>
	private bool eat;
	public bool Eat { get; set; }

	/// <summary>
	/// The timer for the blink function.
	/// </summary>
	private float timer;

	/// <summary>
	/// The time after which special food appears.
	/// </summary>
	private int timeFood;

	// Use this for initialization
	void Start () {
		// Set speed of snake.
		InvokeRepeating ("Movement", 0, Game.Model.SpeedSnake);

		// Get size of camera.
		Game.Model.Width = (int)(Game.View.Camera.GetComponent<Camera> ().orthographicSize * Game.View.Camera.GetComponent<Camera> ().aspect); 
		Game.Model.Height = (int)(Game.View.Camera.GetComponent<Camera> ().orthographicSize - 0.5f);

		// Set next position of head and save current position.
		Game.Model.NextPosition = Vector2.up;
		Game.Model.CurrentDirection = 3;

		// Set initial size of body.
		Game.Model.SizeTail = 4;

		// Set position of normal food.
		SetPosition (Game.View.Food.transform);

		// Set parameters of special food.
		SetSpecialFood(false);

		// Random time to display special food.
		timeFood = Random.Range (10, 20);
	}

	// Update is called once per frame
	void Update()
	{
		// Check collision head of snake with wall.
		CollisionWall ();

		timer += Time.deltaTime; // Increase time
		if (!Game.View.SpecialFood.gameObject.activeSelf && timer > timeFood) // Display special food
		{
			timeFood = Random.Range (10, 20);
			SetPosition (Game.View.SpecialFood.transform);
			SetSpecialFood(true);
		} 
		else if (Game.View.SpecialFood.gameObject.activeSelf) // Function of blink for special food
		{
			if (timer > 10 && timer < 11 || timer > 12 && timer < 13 || timer > 14 && timer < 15)
				Game.View.SpecialFood.GetComponent<Renderer> ().material = Game.View.GrayMaterial;
			else if (timer > 11 && timer < 12 || timer > 13 && timer < 14 || timer > 15 && timer < 16)
				Game.View.SpecialFood.GetComponent<Renderer> ().material = Game.View.OrangeMaterial;
			else if (timer > 16) 
				SetSpecialFood(false);
		}
	}

	/// <summary>
	/// Change the next head position with the mobile phone.
	/// </summary>
	/// <param name="dir">Dir.</param>
	public void ChangeDirection(int dir)
	{
		if (Game.Model.CurrentDirection != 3 && dir == 4) {
			Game.Model.CurrentDirection = dir;
			Game.Model.NextPosition = Vector2.down;
		}
		else if (Game.Model.CurrentDirection != 4 && dir == 3) {
			Game.Model.CurrentDirection = dir;
			Game.Model.NextPosition = Vector2.up;
		}
		else if (Game.Model.CurrentDirection != 1 && dir == 2) {
			Game.Model.CurrentDirection = dir;
			Game.Model.NextPosition = Vector2.left;
		}
		else if (Game.Model.CurrentDirection != 2 && dir == 1) {
			Game.Model.CurrentDirection = dir;
			Game.Model.NextPosition = Vector2.right;
		}
	}

	/// <summary>
	/// Movement of snake.
	/// </summary>
	private void Movement()
	{
		// Save current position head
		Vector2 currentPosition = Game.View.Head.transform.position;

		// Move head into new position
		Game.View.Head.transform.Translate (Game.Model.NextPosition);

		if (Game.Model.SizeTail > 0)
		{
			if (Eat == false) 
			{
				Eat = true;
				Game.Model.SizeTail--;
			}
		}
		
		if (Eat) 
		{
			// Keep track of it our tail list
			Game.Model.Tail.Insert (0, AddTail (currentPosition));

			// Reset the flags
			Eat = false;
		} 
		else if (Game.Model.Tail.Count > 0)
		{
			// Move last Tail Element to where the Head was
			Game.Model.Tail.Last().position = currentPosition;

			// Add to front of list, remove from the back
			Game.Model.Tail.Insert (0, Game.Model.Tail.Last());
			Game.Model.Tail.RemoveAt (Game.Model.Tail.Count - 1);
		}
	}

	/// <summary>
	/// Adds the tail into the world.
	/// </summary>
	/// <returns>The tail transform.</returns>
	/// <param name="position">Position.</param>
	public Transform AddTail(Vector2 position)
	{
		GameObject tail = Instantiate (Game.View.TailPrefab, position, Quaternion.identity);
		return tail.transform;
	}

	/// <summary>
	/// Set a new position food.
	/// </summary>
	/// <param name="food">Food.</param>
	public void SetPosition (Transform food)
	{
		food.position = RandomXY ();
	}

	/// <summary>
	/// Set parameters for the special food.
	/// </summary>
	public void SetSpecialFood(bool visible)
	{
		Game.View.SpecialFood.gameObject.SetActive (visible);
		timer = 0;
	}

	/// <summary>
	/// Random new x and y.
	/// </summary>
	/// <returns>Vector2</returns>
	private Vector2 RandomXY()
	{
		// x position between left and right border
		float x = Random.Range (-Game.Model.Width, Game.Model.Width);

		// y position between top and bottom border
		float y = Random.Range(-Game.Model.Height, Game.Model.Height);

		return new Vector2 (x, y);
	}

	/// <summary>
	/// Collisions the wall.
	/// </summary>
	public void CollisionWall()
	{
		if (Game.View.Head.transform.position.x > Game.Model.Width || Game.View.Head.transform.position.x < -Game.Model.Width 
			|| Game.View.Head.transform.position.y > Game.Model.Height || Game.View.Head.transform.position.y < -Game.Model.Height)
			Exit ();
	}

	/// <summary>
	/// Exit the game.
	/// </summary>
	public void Exit()
	{
		// Set variable score
		PlayerPrefs.SetInt("Score", Game.Model.Score);

		// Stop snake movement
		CancelInvoke ("Movement");

		// GameOver Scene
		SceneManager.LoadScene (2);
	}
}
