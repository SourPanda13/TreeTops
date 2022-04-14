using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //Variables 
    [SerializeField] Transform Player;

    float CameraSmooth = 5f;
    Vector3 cameraOffset;

    void Start(){
        //Offsetting the camera to see the player
        cameraOffset = new Vector3(0.0f, 1.36f, -10.0f);
    }

    void Update(){
        if (Player){
            //Keeping the camera on the player
            Vector3 targetPosition = Player.position + cameraOffset;
            Vector3 SmootherVector = Vector3.Lerp(transform.position, targetPosition, CameraSmooth * Time.deltaTime);
            transform.position = SmootherVector;
        }
    }
}
