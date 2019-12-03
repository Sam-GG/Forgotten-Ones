using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Collision collision;
    public int damage;
    public Player player;
    Rigidbody2D rb;
    Vector2 trajectory;
    float bulletForce = 15f;
    Quaternion newQuaternion;

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
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<Player>();
        trajectory = (player.transform.position - transform.position).normalized * bulletForce;
        rb.velocity = new Vector2(trajectory.x, trajectory.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, transform.rotation.z + 25);

    }
}
