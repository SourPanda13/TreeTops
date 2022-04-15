using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{   
    //Variables
    public PlayerScript player;
    public static bool GameOver = false;
    public GameObject restartMenuUI;
    PauseMenu pausemenu;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Return)){
            if (GameOver){
                pausemenu.Resume();
            }
            else{
                Restart();
            }
        }

    }

    public void Restart(){
        //Restarting the game
        restartMenuUI.SetActive(true);
        //Stopping the time
        Time.timeScale = 0f;
        GameOver = true;
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
