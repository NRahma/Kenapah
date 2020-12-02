using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject home;
    public GameObject bantuan;
    public GameObject berhasil;
    public GameObject audioOn;
    public GameObject audioOff;
    public Button btnBantuan;
    public Button btnHome;
    public AudioSource BGM;

    public void Home()
    {
        home.SetActive(true);
        btnHome.interactable = false;
        btnBantuan.interactable = false;
    }

    public void YaHome()
    {
        SceneManager.LoadSceneAsync(sceneName: "MenuUtama");
    }

    public void TidakHome()
    {
        home.SetActive(false);
        btnHome.interactable = true;
        btnBantuan.interactable = true;
    }

    public void AudioOn()
    {
        audioOn.SetActive(false);
        audioOff.SetActive(true);
    }

    public void AudioOff()
    {
        audioOff.SetActive(false);
        audioOn.SetActive(true);
    }

    public void Bantuan()
    {
        bantuan.SetActive(true);
        btnHome.interactable = false;
        btnBantuan.interactable = false; ;
    }

    public void BatalBantuan()
    {
        bantuan.SetActive(false);
        btnHome.interactable = true;
        btnBantuan.interactable = true;
    }

    public void Ulangi()
    {
        SceneManager.LoadSceneAsync(sceneName: "Organik");
    }
}
