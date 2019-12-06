using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public static AudioClip LaserSound, ExplosionSound, laser5;
	static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        LaserSound = Resources.Load<AudioClip> ("LaserSound");
        ExplosionSound = Resources.Load<AudioClip> ("ExplosionSound");
        laser5 = Resources.Load<AudioClip> ("laser5");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
    	switch(clip)
    	{
    		case "LaserSound":
    			audioSrc.PlayOneShot(LaserSound);
    			break;
            case "ExplosionSound":
                audioSrc.PlayOneShot(ExplosionSound);
                break;
            case "laser5":
                audioSrc.PlayOneShot(laser5);
                break;
        }
    }
}
