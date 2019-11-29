using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int Health = 500;
    public Weapon currentGun;



    // Start is called before the first frame update
    void Start()
    {
        Weapon basic = new Weapon(1, 50, 1, 1);
        this.currentGun = basic;
    }

    public void changeGun(Weapon newWeapon)
    {
        currentGun = newWeapon;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Drop drop = col.gameObject.GetComponent<Drop>();
        if (drop != null)
        {
            currentGun = drop.weapon;
            Destroy(col.gameObject); // this destroys the drop
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            SoundManager.PlaySound("ExplosionSound");
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
