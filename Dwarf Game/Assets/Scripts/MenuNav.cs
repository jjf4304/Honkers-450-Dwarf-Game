using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public GameObject Manager;

    public void LoadGame()
    {
        if (Manager == null)
            Manager = FindObjectOfType<ContinueMusic>().gameObject;
        Destroy(Manager);
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadHelpMenu()
    {
        SceneManager.LoadScene("HelpMenu");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
