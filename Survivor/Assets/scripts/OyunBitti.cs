using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunBitti : MonoBehaviour
{//oyuncunun can degerinin 0 olması ile olusan ölüm ekranı scripti
    public Text puan;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        puan.text = "Puanınız: " + PlayerPrefs.GetInt("puan");
    }
    public void YenidenOyna()
    {
        SceneManager.LoadScene("Survivor");
    }
    public void AnaEkran()
    {
        SceneManager.LoadScene("GirisEkrani");
    }
}
