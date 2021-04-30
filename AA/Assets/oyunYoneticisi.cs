using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyunYoneticisi : MonoBehaviour
{
    GameObject DonenCember;
    GameObject AnaCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text bir;
    public Text iki;
    public Text uc;
    public int kacTaneKucukCemberOlsun;
    bool kontrol = true;
    void Start()
    {
        PlayerPrefs.SetInt("kayit",int.Parse(SceneManager.GetActiveScene().name));
        DonenCember = GameObject.FindGameObjectWithTag("donencembertag");
        AnaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;

        if (kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
        }
        else if(kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }
        
    }
    public void KucukCemberlerdeTextGosterme()
    {
        kacTaneKucukCemberOlsun--;
        if (kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = "";
            uc.text = "";
        }
        else if (kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2)+"";
        }
        if (kacTaneKucukCemberOlsun == 0)
        {
            StartCoroutine(yeniLevel());
        }
        IEnumerator yeniLevel()
        {
            
            DonenCember.GetComponent<Dondurme>().enabled = false;
            AnaCember.GetComponent<AnaCember>().enabled = false;
            yield return new WaitForSeconds(1);
            if (kontrol)
            {
                animator.SetTrigger("YeniLevel");
                yield return new WaitForSeconds(2);
                SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
            }
            
        }
    }

    public void OyunBitti()
    {
        StartCoroutine(CagrilanMetot());
    }
    IEnumerator CagrilanMetot()
    {
        DonenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<AnaCember>().enabled = false;
        animator.SetTrigger("OyunBitti");
        kontrol = false;

        yield return new WaitForSeconds(3/2);
        
        SceneManager.LoadScene("AnaMenu");
    }
}
