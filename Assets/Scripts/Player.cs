using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static int Health = 500;
    public Weapon currentGun;
    public WeaponManager wm;
    public bool GodMode;

    public struct Weapon
    {
        public int fireRate, shotPower, bulletSpeed, rarity;

        public Weapon(int rate, int power, int speed, int r)
        {
            fireRate = rate;
            shotPower = power;
            bulletSpeed = speed;
            rarity = r;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        wm = this.GetComponent<WeaponManager>();
        Weapon basic = wm.createWeapon(1, 29, 1, 1);
        this.currentGun = basic;
    }

    public void changeGun(Weapon newWeapon)
    {
        currentGun.shotPower = newWeapon.shotPower;
        currentGun.fireRate = newWeapon.fireRate;
        currentGun.bulletSpeed = newWeapon.bulletSpeed;
        currentGun.rarity = newWeapon.rarity;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Drop drop = col.gameObject.GetComponent<Drop>();
        if (col.gameObject.tag.Equals("Drop") && drop != null)
        {
            Weapon weapon = wm.generateWeapon(drop.rarity);
            changeGun(weapon);
            Destroy(col.gameObject); // this destroys the drop
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            if (GodMode != true) {
                SoundManager.PlaySound("ExplosionSound");
                FindObjectOfType<GameManager>().EndGame();
            }
            
        }
    }
}
