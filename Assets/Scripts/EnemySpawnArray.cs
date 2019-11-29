using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnArray : MonoBehaviour
{
    //Based on the way i'm doing this script it may need to be part of an 
    //even large container script that calls upon this, but we'll see.
    //It also even seem like i could throw out or reimplement the EnemySpawner script,
    //all into one thing working like this, but hold off.

    public static EnemySpawnArray instance;
	
	public GameObject[] location = new GameObject[10];   //This contains empty oject from spawn array to pass transform coordinates
	
	public EnemySpawner enemySpawner;  //the EnemySpawner object to instantiate
    public GameObject Enemy;
	public states currentState;
    public float SweepSpeed = 0.25f;
    public state currentBehaviour;

    public enum state
    {
        straight,
        wavy,
        loop
    }

    public enum states{
		fullSweep,
        reverseSweep,
        shortSweep,
        flippedShortSweep,
		outsideTwo,
		center,
        staggeredTwoThree,
        twoAndTwo,
        three,
        v,
        upsideDownV
		
	}
	
	void InstantiateSpawner(GameObject location, EnemySpawner enemySpawner){
        enemySpawner.Enemy = Enemy;
        if (currentBehaviour == 0)
        {
            enemySpawner.currentState = 0;
        }
        else if (currentBehaviour == state.wavy){
            enemySpawner.currentState = EnemySpawner.state.wavy;
        }
        else if (currentBehaviour == state.loop)
        {
            enemySpawner.currentState = EnemySpawner.state.loop;
        }

        Vector2 spawnLocation = new Vector2(location.transform.position.x, location.transform.position.y);
        //instantiates enemySpawner into game as "obj"
		EnemySpawner obj = Instantiate(enemySpawner, spawnLocation, Quaternion.identity);
        
		Destroy(obj, 10);
	}
	

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void ExecuteState()
    {
        StartCoroutine("MyCoroutine");
    }

    IEnumerator MyCoroutine()
    {
        float tempSpeed = enemySpawner.speed;
        switch (currentState)
        {

            case states.fullSweep:
                for (int i = 0; i < 10; i++)
                {

                    InstantiateSpawner(location[i], enemySpawner);
                    yield return new WaitForSeconds(SweepSpeed);

                }
                break;
            case states.shortSweep:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateSpawner(location[i], enemySpawner);
                    yield return new WaitForSeconds(SweepSpeed);

                }
                break;
            case states.flippedShortSweep:
                for (int i = 9; i >= 5; i--)
                {
                    InstantiateSpawner(location[i], enemySpawner);
                    yield return new WaitForSeconds(SweepSpeed);

                }
                break;
            case states.v:
                int a = 5;
                for (int i = 4; i >= 0; i--)
                {
                    InstantiateSpawner(location[i], enemySpawner);
                    InstantiateSpawner(location[a], enemySpawner);
                    a++;
                    yield return new WaitForSeconds(SweepSpeed);
                }
                break;
            case states.upsideDownV:
                a = 9;
                for (int i = 0; i < 5; i++)
                {
                    InstantiateSpawner(location[a], enemySpawner);
                    InstantiateSpawner(location[i], enemySpawner);
                    a--;
                    yield return new WaitForSeconds(SweepSpeed);
                }
                break;
            case states.outsideTwo:
                InstantiateSpawner(location[8], enemySpawner);
                InstantiateSpawner(location[2], enemySpawner);

                break;
            case states.center:
                //instead for now, have these enemy travel slower:

                //enemySpawner.speed = enemySpawner.speed / 2;
                InstantiateSpawner(location[4], enemySpawner);
                InstantiateSpawner(location[5], enemySpawner);

                //enemySpawner.speed = tempSpeed;

                //Trying to implement enemies stopping half way on screen here, yet to work
                //yield return new WaitForSeconds(3);
                //float tempSpeed = enemySpawner.speed;
                //enemySpawner.speed = 2f;
                //yield return new WaitForSeconds(2);
                //enemySpawner.speed = tempSpeed;
                //instead for now, have these enemy travel slower

                break;
            case states.reverseSweep:
                for (int i = 9; i >= 0; i--)
                {
                    InstantiateSpawner(location[i], enemySpawner);
                    yield return new WaitForSeconds(SweepSpeed);
                }
                break;
            case states.staggeredTwoThree:
                //instead for now, have these enemy travel slower:
                
                //enemySpawner.speed = (enemySpawner.speed / 2);
               
                InstantiateSpawner(location[3], enemySpawner);
                InstantiateSpawner(location[6], enemySpawner);
                yield return new WaitForSeconds((enemySpawner.speed)/6);
                InstantiateSpawner(location[1], enemySpawner);
                InstantiateSpawner(location[4], enemySpawner);
                InstantiateSpawner(location[5], enemySpawner);
                InstantiateSpawner(location[8], enemySpawner);
                //Trying to implement enemies stopping half way on screen here, yet to work
                //GameObject enemy = enemySpawner.transform.Find("obj").gameObject;
                //yield return new WaitForSeconds(3);
                //tempSpeed = enemySpawner.speed;
                //enemy.speed = 2f;
                //yield return new WaitForSeconds(2);
                //enemy.speed = tempSpeed;       
                //enemySpawner.speed = tempSpeed;
                break;
            case states.twoAndTwo:
                InstantiateSpawner(location[0], enemySpawner);
                InstantiateSpawner(location[2], enemySpawner);
                InstantiateSpawner(location[7], enemySpawner);
                InstantiateSpawner(location[9], enemySpawner);
                break;
            case states.three:
                InstantiateSpawner(location[1], enemySpawner);
                InstantiateSpawner(location[4], enemySpawner);
                InstantiateSpawner(location[7], enemySpawner);
                break;
            default:
                break;
        }

        

    }

}
