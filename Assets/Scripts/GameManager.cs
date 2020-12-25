using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverUI;


    public GameObject attackedBuilding;
    public GameObject shatteredBuilding;
    public float waitTime = 4f;
    private bool isShatteredBuildingSet;


    private float breakDownDelay = 0f;
    void Start()
    {
        gameIsOver = false;
        isShatteredBuildingSet = false;
    }
    void Update()
    {
        if (gameIsOver)
            return;

        if(Input.GetKeyDown("e"))
        {
            Close();
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        } 
    }
    public void EndGame()
    {

        if(!isShatteredBuildingSet)
        {
            isShatteredBuildingSet = true;
            Instantiate(shatteredBuilding, attackedBuilding.transform.position, attackedBuilding.transform.rotation);
            Destroy(attackedBuilding);
        }


        if(breakDownDelay <= waitTime)
        {
            breakDownDelay += Time.deltaTime;
        }
        else
        {
            isShatteredBuildingSet = false;
            breakDownDelay = 0f;
            gameIsOver = true;
            Debug.Log("GameEnded");
            gameOverUI.SetActive(true);
        }
        
    }
    public void Close()
    {
        gameOverUI.SetActive(true);
    }
}
