using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject Bullet;
	public GameObject Enemy;
	private Enemy enemy;

     Collision collision;
	void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag.Equals("Bullet"))
        {
            ScoreScript.scoreValue += 10;
            SoundManager.PlaySound("ExplosionSound");
            //enemy.health(50f); 
            Destroy(col.gameObject);
            Destroy(gameObject); // this destroys the bullet
        }
        //if (col.gameObject.tag.Equals("Player"))
        //{
          //  movement.enabled = false;
            //FindObjectOfType<GameManager>().EndGame();
        //}
    }
}
