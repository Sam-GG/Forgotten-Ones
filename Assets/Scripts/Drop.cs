using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public int rarity;
    //public GameObject p1,p2,p3;

        /*
    public Drop(Vector3 pos, GameObject p1, GameObject p2, GameObject p3)
    {
        wm = GameObject.Find("SpaceShip").GetComponent<WeaponManager>(); 
        weapon = wm.GenerateWeapon();
        CreateDrop(pos, p1, p2, p3);
    }

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
        GameObject dropObject;
        Drop drop;
        float rand = Random.Range(1f, 100f);
        if (rand < 60f)
        {
            dropObject = Instantiate(p1, new Vector2(pos.x, pos.y), Quaternion.identity);
            drop = dropObject.GetComponent<Drop>();
            drop.rarity = 1;
        }
        else if (rand >= 60 && rand <= 95)
        {
            dropObject = Instantiate(p2, new Vector2(pos.x, pos.y), Quaternion.identity);
            drop = dropObject.GetComponent<Drop>();
            drop.rarity = 2;
        }
        else
        {
            dropObject = Instantiate(p3, new Vector2(pos.x, pos.y), Quaternion.identity);
            drop = dropObject.GetComponent<Drop>();
            drop.rarity = 3;
        }
        Destroy(dropObject, 4);
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
