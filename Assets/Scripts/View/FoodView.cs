using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes the normal food.
/// </summary>
public class FoodView : GameElement
{
	/// <summary>
	/// Callback called upon collision.
	/// </summary>
	/// <param name="coll">Coll.</param>
	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Tail" || coll.tag == "SpecialFood")
			Game.Controller.SetPosition (this.gameObject.transform);
	}
}
