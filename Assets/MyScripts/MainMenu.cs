using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip MenuClick;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        audioSource.PlayOneShot(MenuClick, 1.0f);
        Invoke("PlayGameReal", 0.5f);
    }
    public void QuitGame()
    {
        audioSource.PlayOneShot(MenuClick, 1.0f);
        Invoke("QuitGameReal", 0.5f);

    }
    void PlayGameReal()
    {
        SceneManager.LoadScene(1);
    }
    void QuitGameReal()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
