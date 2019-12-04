using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBGChange : MonoBehaviour
{
    public Texture[] SpaceBGs;
    float tempTime = 5f;
    BGScroll control;
    BGScroll StarControl;
    GameObject Stars;
    int changeLevel = 0;
    int Level = 1;
    int nextLevel = 300;
    int textureChoice;
    float currentScrollSpeedSpace = 1f;
    float currentScrollSpeedStars = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        control = gameObject.GetComponent<BGScroll>();       
        Stars = gameObject.transform.GetChild(0).gameObject;
        StarControl = Stars.GetComponent<BGScroll>();
        textureChoice = (int)UnityEngine.Random.Range(0, SpaceBGs.Length);
        gameObject.GetComponent<Renderer>().sharedMaterial.mainTexture = SpaceBGs[textureChoice];
    }

    void ChangeBG()
    {
        int temp = textureChoice;
        while (textureChoice == temp)
        {
            textureChoice = (int)UnityEngine.Random.Range(0, SpaceBGs.Length);
        }
        gameObject.GetComponent<Renderer>().sharedMaterial.mainTexture = SpaceBGs[textureChoice];
        currentScrollSpeedSpace = currentScrollSpeedSpace * 1.25f;
        currentScrollSpeedStars = currentScrollSpeedStars * 1.25f;
        control.scroll_Speed = currentScrollSpeedSpace;
        StarControl.scroll_Speed = currentScrollSpeedStars;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreScript.scoreValue >= nextLevel)
        {
            Level += 1;
            nextLevel += 300;
            ChangeBG();
        }

    }
}
