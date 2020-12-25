using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howtoplay;
    public GameObject menu;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
    public void HowToPlay()
    {
        menu.SetActive(false);
        howtoplay.SetActive(true);
        DialogueTrigger trigger = transform.GetComponent<DialogueTrigger>();
        trigger.TriggerDialogue();
    }
}
