using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControl : MonoBehaviour
{
    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    void Start()
    {
        SoundOnButton.SetActive(false);
        SoundOffButton.SetActive(true);
    }


    public void GoToLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }

     
    public void SoundOn()
    {
        SoundOnButton.SetActive(false);
        SoundOffButton.SetActive(true);
    }

    public void SoundOff()
    {
        SoundOffButton.SetActive(false);
        SoundOnButton.SetActive(true);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
