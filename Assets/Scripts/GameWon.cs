using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameWon : MonoBehaviour
{

    public Text roundtext;
    public GameObject ShopUI;
    public GameObject lifeUI;
    public GameObject Errormessage;
    
    void OnEnable()
    {
        roundtext.text = PlayerStats.Rounds.ToString();
        ShopUI.SetActive(false);
        lifeUI.SetActive(false);
        Errormessage.SetActive(false);

    }
    public void NextLevel()
    {
        Debug.Log("Next Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
