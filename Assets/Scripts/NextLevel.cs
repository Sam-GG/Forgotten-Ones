using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public static int lvl = 1;
    int tempLvl = 1;
    Text level;
    [SerializeField] private Animator animController;

    // Start is called before the first frame update
    void Start()
    {
        level = GetComponent<Text>();
        animController.SetTrigger("LevelUp");
    }

    void playNextLevelAnimation()
    {
        //gameObject.GetComponent<Animator>();
        animController.SetTrigger("LevelUp");
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level " + lvl;
        if (tempLvl != lvl)
        {
            playNextLevelAnimation();
            tempLvl += 1;
        }
    }
}
