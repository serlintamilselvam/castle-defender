using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text roundtext;
    public GameObject ShopUI;
    public AudioClip gameoveraudio;
    public GameObject Errormessage;
    public GameObject lifeUI;

    void OnEnable()
    {
        roundtext.text = PlayerStats.Rounds.ToString();
        AudioSource.PlayClipAtPoint(gameoveraudio, transform.position);
        ShopUI.SetActive(false);
        Errormessage.SetActive(false);
        lifeUI.SetActive(false);


    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       SceneManager.LoadScene("MainMenu");
    }
   
}
