using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	bool GameEnded = false;

	public void EndGame()
	{
		if (GameEnded == false)
		{
			GameEnded = true;
			Debug.Log("Game Over");
            SceneManager.LoadScene("LeaderBoardSampleScene");
            //Restart();
        }
	}

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(3);
    }

    public void Restart()
	{
		SceneManager.LoadScene("Menu");
	}
}
