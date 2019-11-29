using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Collision collision;
    public int damage;



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Player player = GameObject.Find("SpaceShip").GetComponent<Player>();
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            player.Health -= 100;
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
