using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    Weapon weapon;

    // Creates a randomizd weapon
    public Weapon GenerateWeapon()
    {

        float rand = Random.Range(1f, 100f);
        if (rand < 60)
        {
            weapon = new Weapon((int)Random.Range(0, 4), (int)Random.Range(50, 100), (int)Random.Range(0, 4), 1);
        }
        else if (rand >= 60 && rand <= 95)
        {
            weapon = new Weapon((int)Random.Range(5, 7), (int)Random.Range(100, 150), (int)Random.Range(5, 7), 2);
        }
        else
        {
            weapon = new Weapon((int)Random.Range(8, 10), (int)Random.Range(150, 200), (int)Random.Range(8, 10), 3);
        }
        return weapon;
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
