using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes the head snake.
/// </summary>
public class HeadView : GameElement
{
	/// <summary>
	/// Callback called upon collision.
	/// </summary>
	/// <param name="coll">Coll.</param>
	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "NormalFood" || coll.tag == "SpecialFood") 
		{
			Game.Controller.Eat = true;
			if (coll.tag == "NormalFood") {
				Game.Controller.SetPosition (Game.View.Food.transform);
				Game.Model.Score++;
			} else if (coll.tag == "SpecialFood") {
				Game.Controller.SetSpecialFood(false);
				Game.Model.Score += 10;
			}

			Game.View.ScoreText.text = Game.Model.Score.ToString ();
		} 
		else if (coll.tag == "Tail")
		{
			Game.Controller.Exit ();
		}
	}
}
