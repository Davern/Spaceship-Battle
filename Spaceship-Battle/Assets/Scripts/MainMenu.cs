using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void PlayLevel(int i)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
