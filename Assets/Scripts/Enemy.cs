using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int CurrHealth = 200;
    public GameObject dropPrefab;
    public GameObject dropPrefab1;
    public GameObject dropPrefab2;
    public Transform firePoint;
    public GameObject bullet;
    public bool canShoot = true;
    private float nextTimeToShoot = 0;
    public float bulletForce = 20f;

    public void health(int damage, Vector3 pos){ // get the damage and the location of the hit
        CurrHealth = CurrHealth - damage;
        //health check
        if (CurrHealth <= 0)
        {
            Die(pos);
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bulletObj.GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(rb.velocity.x, -bulletForce + 2);
        Destroy(bulletObj, 2);
    }

    public void Die(Vector3 pos)
    {
        Destroy(gameObject); //destroys enemy
        Drop drop = new Drop(pos, dropPrefab, dropPrefab1, dropPrefab2);
    }
	
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner enemySpawner = GetComponentInParent<EnemySpawner>();
        canShoot = enemySpawner.canShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
        {
            if (Time.time >= nextTimeToShoot)
            {
                SoundManager.PlaySound("LaserSound");
                Shoot();
                nextTimeToShoot = Time.time + 2f;
            }
        }
        
    }
}
