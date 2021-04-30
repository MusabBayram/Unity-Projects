using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenu : MonoBehaviour
{
    public Text skorText;
    public Text sonSkorText;
    private void Start()
    {
        int enYuksekSkor = PlayerPrefs.GetInt("kayit");
        int sonSkor = PlayerPrefs.GetInt("puanKayit");

        skorText.text = "Best Skor = " + enYuksekSkor;
        sonSkorText.text = "Skorun = " + sonSkor;
    }
    public void OyunaGit()
    {
        SceneManager.LoadScene("Flappy");
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
}
