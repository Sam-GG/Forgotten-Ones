using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Collision collision;
    public int damage;
	


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            Player player = GameObject.Find("SpaceShip").GetComponent<Player>();
            enemy.health(player.currentGun.shotPower, col.GetContact(0).point);
            Destroy(gameObject); // this destroys the bullet
        }
    }
	
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
