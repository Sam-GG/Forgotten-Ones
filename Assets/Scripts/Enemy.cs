using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Drop
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
    public float fireRate = 2f;
    public GameObject enemyExplosion;
    Vector3 enemyDeathLocation;

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
        //bullet.bulletForce = bulletForce;
        GameObject bulletObj = Instantiate(bullet, firePoint.position, Quaternion.identity);
        //bullet.transform.rotation
        Destroy(bulletObj, 3);
    }

    public void Die(Vector3 pos)
    {
        
        //Drop drop = GameObject.Find("SpaceShip").GetComponent<Drop>();
        float rand = Random.Range(0, 25);
        if (rand >= 7 && rand <= 8)
        {
            CreateDrop(pos, dropPrefab, dropPrefab1, dropPrefab2);
        }
        ScoreScript.scoreValue += 10;
        SoundManager.PlaySound("ExplosionSound");
        Instantiate(enemyExplosion, pos, Quaternion.identity);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        EnemySpawner enemySpawner = GetComponentInParent<EnemySpawner>();       
        canShoot = enemySpawner.canShoot;
        fireRate = enemySpawner.fireRate;       
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
                nextTimeToShoot = Time.time + fireRate;
            }
        }
        
    }
}
