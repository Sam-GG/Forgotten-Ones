using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public PlayerMovement movement;
    Player player;


	void OnCollisionEnter2D (Collision2D col)
	{
        player = gameObject.GetComponent<Player>();
        if (player.GodMode != true) {
            if (col.gameObject.tag.Equals("Enemy"))
            {
                Player.Health -= 200;
            }
        } 
		
	}
}
