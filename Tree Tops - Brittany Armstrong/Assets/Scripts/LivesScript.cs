using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesScript : MonoBehaviour
{
    //Variables
    [SerializeField] TextMeshProUGUI LivesText;
    [SerializeField] PlayerScript player;

    private void Start(){
        player.Life = player.Life + 1;
    }

    void Update()
    {
        //Printing the Life count
        LivesText.text = player.Life.ToString();
    }
}
