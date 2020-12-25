using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    public Text LiveText;
    // Update is called once per frame
    void Update()
    {
        LiveText.text =  "LIVES:" +PlayerStats.Lives.ToString();
    }
}
