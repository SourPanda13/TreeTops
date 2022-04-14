using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Variables
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    void Update(){
        //Pausing and unpausing the game
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }

    }

    public void Resume(){
        //Resuming the game
        pauseMenuUI.SetActive(false);
        //Continues the time
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){
        //Pausing the game
        pauseMenuUI.SetActive(true);
        //Stopping the time
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(){
        //Loading the Main Menu via the build index
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
