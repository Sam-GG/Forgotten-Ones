using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    int currTempHealth;
    // Start is called before the first frame update
    void Start()
    {
        currTempHealth = Player.Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Health < currTempHealth)
        {
            if (Player.Health < currTempHealth - 100)
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x - 6, transform.localScale.y, transform.localScale.z);               
            }
            else
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x - 3, transform.localScale.y, transform.localScale.z);
            }

            SoundManager.PlaySound("ExplosionSound");
            currTempHealth = Player.Health;
        }
    }
}
