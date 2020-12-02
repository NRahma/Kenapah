using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mulai;
    public GameObject bantuan;
    public GameObject tentang;
    public GameObject keluar;
    public GameObject audioOn;
    public GameObject audioOff;
    public Button btnBantuan;
    public Button btnMulai;
    public Button btnTentang;
    public Button btnKeluar;
    public AudioSource BGM;

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
    public void Mulai()
    {
        mulai.SetActive(true);
        btnBantuan.interactable = false;
        btnMulai.interactable = false;
        btnTentang.interactable = false;
        btnKeluar.interactable = false;        
    }

    public void BatalMulai()
    {
        mulai.SetActive(false);
        btnBantuan.interactable = true;
        btnMulai.interactable = true;
        btnTentang.interactable = true;
        btnKeluar.interactable = true;
    }

    public void Organik()
    {
        SceneManager.LoadSceneAsync(sceneName: "Organik");
    }

    public void Anorganik()
    {
        SceneManager.LoadSceneAsync(sceneName: "Anorganik");
    }

    public void BBB()
    {
        SceneManager.LoadSceneAsync(sceneName: "B3");
    }

    public void Bantuan()
    {
        bantuan.SetActive(true);
        btnBantuan.interactable = false;
        btnMulai.interactable = false;
        btnTentang.interactable = false;
        btnKeluar.interactable = false;
    }

    public void BatalBantuan()
    {
        bantuan.SetActive(false);
        btnBantuan.interactable = true;
        btnMulai.interactable = true;
        btnTentang.interactable = true;
        btnKeluar.interactable = true;
    }

    public void Tentang()
    {
        tentang.SetActive(true);
        btnBantuan.interactable = false;
        btnMulai.interactable = false;
        btnTentang.interactable = false;
        btnKeluar.interactable = false;
    }

    public void BatalTentang()
    {
        tentang.SetActive(false);
        btnBantuan.interactable = true;
        btnMulai.interactable = true;
        btnTentang.interactable = true;
        btnKeluar.interactable = true;
    }

    public void Keluar()
    {
        keluar.SetActive(true);
        btnBantuan.interactable = false;
        btnMulai.interactable = false;
        btnTentang.interactable = false;
        btnKeluar.interactable = false;
    }

    public void BatalKeluar()
    {
        keluar.SetActive(false);
        btnBantuan.interactable = true;
        btnMulai.interactable = true;
        btnTentang.interactable = true;
        btnKeluar.interactable = true;
    }

    public void YaKeluar()
    {
        Application.Quit();
    }
}
