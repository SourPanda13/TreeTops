using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Variables
    Rigidbody2D playerRB;
    Animator playerAnimator;
    Collider2D playerCollider;

    [HideInInspector] public int AcornsCollected = 0;

    float PlayerSpeed = 10000;
    float JumpSpeed = 1;
    float RollSpeed = 1;
    int Life = 2;
    bool IsAlive = true;
    public bool GameEnded = false;

    void Start(){
        //Getting references of the components
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update(){
        //Checking the player is alive
        if (IsAlive){
            PlayerMovement();
            Jump();
            Roll();
        }

        if (Input.GetKey(KeyCode.RightArrow)){
            playerRB.velocity = Vector2.right;
        }
    }

    private void PlayerMovement(){
        //Getting input and moving the character
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * PlayerSpeed * Time.deltaTime, playerRB.velocity.y);
        playerRB.velocity = playerVelocity;

        //Rotating the character
        if(Input.GetAxis("Horizontal") < 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(Input.GetAxis("Horizontal") > 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        bool playerHorizontalMove = false;

        if(Mathf.Abs(controlThrow) > 0){
            playerHorizontalMove = true;
        }
        else{
            playerHorizontalMove = false;
        }
        AnimationChange(playerHorizontalMove);
    }

    private void AnimationChange(bool playerHorizontalMove){
        //Changing the animator controller variable to play different animations
        playerAnimator.SetBool("CanRun", playerHorizontalMove);
    }

    private void Jump(){
        //Jumping
        if (Input.GetButton("Jump")){
            playerAnimator.SetBool("CanJump", true);
            bool isTouchingGround = playerCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));
            if (isTouchingGround){
                Vector2 JumpVelocity = new Vector2(0, JumpSpeed);
                playerRB.velocity += JumpVelocity;
            }
        }
        else{
            playerAnimator.SetBool("CanJump", false);
        }
    }

    private void Roll(){
        //Rolling 
        if (Input.GetButton("Vertical")){
            playerAnimator.SetBool("CanRoll", true);
            bool isTouchingGround = playerCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));
            if (isTouchingGround){
                Vector2 RollVelocity = new Vector2(RollSpeed, 0);
                playerRB.velocity += RollVelocity;
            }
        }
        else
        {
            playerAnimator.SetBool("CanRoll", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //If collected acorns
        if (collision.gameObject.CompareTag("Acorn")){
            AcornsCollected++;
            Destroy(collision.gameObject);
        }

        //Collision with enemies 
        if (collision.gameObject.CompareTag("Enemy")){
            Life--;
            Destroy(collision.gameObject);
            if(Life < 0){
                IsAlive = false;
                //playerAnimator.SetTrigger("DeathTrigger");
                Destroy(gameObject, 2);
                LoseLevel();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){
        //Win conditions
        if (collision.gameObject.CompareTag("Environment")){
            if (AcornsCollected >= 5){
                WinLevel();
                //Restart();
            }
            else{
                LoseLevel();
            }
        }
    }

    /*public GameObject restartMenuUI;

    public void Restart()
    {
        restartMenuUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    public void WinLevel(){
        Debug.Log("You Win!");
        GameEnded = true;
    }

    public void LoseLevel(){
        Debug.Log("You Lose!");
        GameEnded = true;
    }
}
