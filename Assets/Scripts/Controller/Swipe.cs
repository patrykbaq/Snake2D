﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Swipe controller for phone.
/// </summary>
public class Swipe : GameElement
{
	/// <summary>
	/// First/Last finger position  
	/// </summary>
	private Vector3 fp,lp;  

	/// <summary>
	/// Distance needed for a swipe to take some Action
	/// </summary>
	public float DragDistance;  

	void Update()  
	{  
		//Check the touch inputs  
		foreach (Touch touch in Input.touches)  
		{  
			if (touch.phase == TouchPhase.Began)  
			{  
				fp = touch.position;  
				lp = touch.position;  
			}  

			if (touch.phase == TouchPhase.Moved)  
			{  
				lp = touch.position;  
			}  

			if (touch.phase == TouchPhase.Ended)  
			{  
				//First check if it’s actually a drag  
				if (Mathf.Abs(lp.x - fp.x) > DragDistance || Mathf.Abs(lp.y - fp.y) > DragDistance)  
				{ //It’s a drag  
					//Now check what direction the drag was  
					//First check which axis  
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))  
					{  
						//If the horizontal movement is greater than the vertical movement…  
						if (lp.x > fp.x)  
						{ 
							//Right move   
							Game.Controller.ChangeDirection(1);
						}  
						else  
						{ 
							//Left move   
							Game.Controller.ChangeDirection(2);
						}  
					}  
					else  
					{  
						//the vertical movement is greater than the horizontal movement  
						if (lp.y > fp.y)  
						{  
							//Up move    
							Game.Controller.ChangeDirection(3);
						}  
						else  
						{  
							//Down move   
							Game.Controller.ChangeDirection(4);
						}  
					}  
				}  
			}  
		}  
	}  
}
