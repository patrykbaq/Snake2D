using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes the special food.
/// </summary>
public class SpecialFoodView : GameElement
{
	/// <summary>
	/// Callback called upon collision.
	/// </summary>
	/// <param name="coll">Coll.</param>
	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Tail" || coll.tag == "NormalFood")
			Game.Controller.SetPosition (this.gameObject.transform);
	}
}
