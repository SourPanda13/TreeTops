using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcornScript : MonoBehaviour
{
    //Variables
    [SerializeField] TextMeshProUGUI AcornText;
    [SerializeField] PlayerScript player;

    void Update(){
        AcornText.text = player.AcornsCollected.ToString();
    }
}
