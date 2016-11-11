using System.Net;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeControl : MonoBehaviour
{

	//Get reference to the player movement script
	private Player _player;

	[Range(0, 5)]
	public float TimeScale = 1.0f;

	// Alway check for the input of the time by player.
	private void Update()
	{
		Time.timeScale = TimeScale;
		TimeController();
	}

	public void TimeController()
	{
		//Keep track of the player pressing the attack button.
		int shootCount = 0;
		if (_player._shootKey)
		{
			shootCount++;

			//Check if the player attacks have exceeded the constrain
			if (shootCount >= 5)
			{
				//Display that the player have reached their limit.
				bool limitReached = true;
				print("Limit reached, slow down time:");
				TimeScale /= 2;		
			}
			
			//Display the count of attack the player have taken
			print("Player_Attacks: " + shootCount);		
		}
	}
}