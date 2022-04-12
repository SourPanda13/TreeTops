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
        cameraOffset = new Vector3(0.0f, 1.36f, -10.0f);
    }

    void Update(){
        if (Player){
            Vector3 targetPosition = Player.position + cameraOffset;
            Vector3 SmootherVector = Vector3.Lerp(transform.position, targetPosition, CameraSmooth * Time.deltaTime);
            transform.position = SmootherVector;
        }
    }
}
