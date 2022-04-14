using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Variables
    public static bool GameIsPaused = false;
    public static bool LevelDone = false;
    public GameObject pauseMenuUI;
    public GameObject restartMenuUI;

    PlayerScript playerscript;

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

        if (LevelDone == false){
            Resume();
        }
        else{ 
            Restart();
        }

    }

    public void Resume(){
        //Resuming the game
        pauseMenuUI.SetActive(false);
        //Continues the time
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause(){
        //Pausing the game
        pauseMenuUI.SetActive(true);
        //Stopping the time
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart(){
        restartMenuUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
