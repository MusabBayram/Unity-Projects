using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyunWin : MonoBehaviour
{//oyuncunun oyunu kazandıgında gerceklesen olayları kontrol eden script
    public GameObject gemi;
    public Text puan;
    void Start()
    {
        gemi.GetComponent<Animation>().Play("OyunWinAnim");
        if(PlayerPrefs.GetInt("puan")> PlayerPrefs.GetInt("bestSkor"))
        {
            puan.text = "Yeni Skor: "+ PlayerPrefs.GetInt("puan");
        }
        else
        {
            puan.text = "Puanınız: " + PlayerPrefs.GetInt("puan");
        }
    }
}
