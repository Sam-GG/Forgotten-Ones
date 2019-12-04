using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Player
{

    
    // Creates a randomizd weapon
    public Weapon generateWeapon(int rarity)
    {
        Weapon weapon;
        if (rarity == 1)
        {
            weapon = new Weapon((int)Random.Range(0, 4), (int)Random.Range(24, 40), (int)Random.Range(0, 4), 1);
        }
        else if (rarity == 2)
        {
            weapon = new Weapon((int)Random.Range(5, 7), (int)Random.Range(45, 52), (int)Random.Range(5, 7), 2);
        }
        else
        {
            weapon = new Weapon((int)Random.Range(8, 10), (int)Random.Range(66, 100), (int)Random.Range(8, 10), 3);
        }
        return weapon;
    }

    public Weapon createWeapon(int rate, int power, int speed, int r)
    {
        Weapon newWeapon = new Weapon(rate, power, speed, r);
        return newWeapon;
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
