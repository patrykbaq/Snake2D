using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Root class for all views.
/// </summary>
public class GameView : GameElement
{
	/// <summary>
	/// Reference to the Head View.
	/// </summary>
	public HeadView Head;

	/// <summary>
	/// Reference to the normal Food View.
	/// </summary>
	public FoodView Food;

	/// <summary>
	/// Reference to the special Food View.
	/// </summary>
	public SpecialFoodView SpecialFood;

	/// <summary>
	/// Reference to the material gray.
	/// </summary>
	public Material GrayMaterial;

	/// <summary>
	/// Reference to the material orange.
	/// </summary>
	public Material OrangeMaterial;

	/// <summary>
	/// The tail prefab.
	/// </summary>
	public GameObject TailPrefab;

	/// <summary>
	/// The camera.
	/// </summary>
	public GameObject Camera;

	/// <summary>
	/// The score text of the game.
	/// </summary>
	public Text ScoreText;
}
