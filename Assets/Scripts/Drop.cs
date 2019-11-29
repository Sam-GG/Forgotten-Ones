using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public WeaponManager wm;
    public Weapon weapon;
    //public GameObject p1,p2,p3;

    public Drop(Vector3 pos, GameObject p1, GameObject p2, GameObject p3)
    {
        wm = GameObject.Find("SpaceShip").GetComponent<WeaponManager>(); 
        weapon = wm.GenerateWeapon();
        CreateDrop(pos, p1, p2, p3);
    }
    /*

    void OnCollisionEnter2D(Collision2D col)
    {       
        if (col.gameObject.tag.Equals("Player"))
        {
            player = GameObject.Find("SpaceShip").GetComponent<Player>();
            player.changeGun(weapon);
            Destroy(gameObject); // this destroys the drop
        }
    }
    */

    public void CreateDrop(Vector3 pos, GameObject p1, GameObject p2, GameObject p3)
    {
        GameObject dropPrefab;
        float rand = Random.Range(0, 10);
        if (rand >= 7 && rand <= 8)
        {
            if (weapon.rarity == 1)
            {
                dropPrefab = Instantiate(p1, new Vector2(pos.x, pos.y), Quaternion.identity);
            }
            else if (weapon.rarity == 2)
            {
                dropPrefab = Instantiate(p2, new Vector2(pos.x, pos.y), Quaternion.identity);
            }
            else
            {
                dropPrefab = Instantiate(p3, new Vector2(pos.x, pos.y), Quaternion.identity);
            }
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
