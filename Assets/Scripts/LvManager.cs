using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LvManager : MonoBehaviour {
    public int maxGameLevel;

    private int currentLevel; 
    private static int gameLevelIndex=1;
    private static int previousScene;

	public void LvLoader (string name){
        previousScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(name);
	}

    public void PlayAgain()
    {
        SceneManager.LoadScene(previousScene);
    }

//	public void LvLoader_quit (string name){
//		SceneManager.LoadScene(name);
//	}

    public void LoadNextLv()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (gameLevelIndex == maxGameLevel)
        {
            gameLevelIndex =1;
            SceneManager.LoadScene("Win");
        }else{
           gameLevelIndex++;
           SceneManager.LoadScene(currentLevel + 1);
        }
    }

	}

    // Remember reset the max level in prefab;