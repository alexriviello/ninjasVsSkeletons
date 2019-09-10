using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] int delayInSeconds = 6;

    int currentSceneIndex;


    void Start(){
    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
//        else
  //          currentSceneIndex++;
        }


    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(delayInSeconds); //waits three seconds
        LoadNextScene(); //loads start screen in this case

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
