using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public float bulletForce = 40f;
    Player player;
    public float nextShot = 0.0f;
    public float myTime = 0.0f;
    public float shotPeriod;
	
    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;
    	if (Input.GetButton("Fire1") && myTime >= nextShot)
    	{
            nextShot = myTime + shotPeriod;
    		Shoot();
            nextShot = nextShot - myTime;
            myTime = 0.0f;
    	}
    }

    void Shoot()
    {
        GameObject bullet;
        player = GameObject.Find("SpaceShip").GetComponent<Player>();
        SoundManager.PlaySound("laser5");
        if (player.currentGun.rarity == 1)
        {
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else if(player.currentGun.rarity == 2)
        {
            bullet = Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation);
        }
        else
        {
            bullet = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
        }
    	Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    	rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 1);
    }
}
