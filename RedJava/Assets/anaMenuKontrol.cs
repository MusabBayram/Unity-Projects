using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class anaMenuKontrol : MonoBehaviour
{
    GameObject level1, level2, level3,leveller;
    GameObject kilit1, kilit2, kilit3, kilitler;
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        leveller = GameObject.Find("Leveller");
        kilitler = GameObject.Find("kilitler");

        for(int i = 0; i < leveller.transform.childCount; i++)
        {
            leveller.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < kilitler.transform.childCount; i++)
        {
            kilitler.transform.GetChild(i).gameObject.SetActive(false);
        }


        for (int i = 0; i < PlayerPrefs.GetInt("kacinciLevel"); i++)
        {
            leveller.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }

    }
    public void butonSec(int gelenButon)
    {
        if (gelenButon == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if(gelenButon == 2)
        {
            for (int i = 0; i < leveller.transform.childCount; i++)
            {
                leveller.transform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i < kilitler.transform.childCount; i++)
            {
                kilitler.transform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i < PlayerPrefs.GetInt("kacinciLevel"); i++)
            {
                kilitler.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if(gelenButon == 3)
        {
            Application.Quit();
        }
    }
    public void levellerButton(int gelenLevel)
    {
        SceneManager.LoadScene(gelenLevel);
    }

}
