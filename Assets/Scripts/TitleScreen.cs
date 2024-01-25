using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{

    public string firstLevel;

    public GameObject HowPlayScreen;

    public GameObject CreditsScreen;

    public GameObject SoundScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenHowPlay()
    {
        HowPlayScreen.SetActive(true);
    }

    public void CloseHowPlay()
    {
        HowPlayScreen.SetActive(false);
    }

    public void OpenCredits()
    {
        CreditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsScreen.SetActive(false);
    }

    public void OpenSound()
    {
        SoundScreen.SetActive(true);
    }

    public void CloseSound()
    {
        SoundScreen.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
