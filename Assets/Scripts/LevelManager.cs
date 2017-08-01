using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        //Application.LoadLevel(name);
        //Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }
	
    public void Quit()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void BrickDestroyed()
    //{
    //    if (Brick.breakableCount <= 0)    //if last brick destroyed
    //    {
    //        LoadNextLevel();
    //    }
    //}
}
