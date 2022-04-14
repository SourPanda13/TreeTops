using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Variables
    Rigidbody2D EnemyRB;
    bool obstacleActive = true;

    void Start(){
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Enemy")){
            //obstacleActive = false;
            transform.localScale = new Vector3(Mathf.Sign(EnemyRB.velocity.x), 1, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        
    }
}
