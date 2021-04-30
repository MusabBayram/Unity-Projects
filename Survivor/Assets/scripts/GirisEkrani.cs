using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GirisEkrani : MonoBehaviour
{//oyunun acılıs sahnesinin ve ayarlarının scripti
    public GameObject kolay, orta, zor;
    public GameObject ortaKilit;
    public GameObject zorKilit;
    int sayac = 0;
    public Text Skor;
    public Text isim;
    public Text bilgilendirme;
    string Id;
    void Start()
    {
        PlayerPrefs.SetInt("zorlukHiz", 10);
        PlayerPrefs.SetInt("zorlukCan", 5);
        Skor.text = "En Yüksek Skor: " + PlayerPrefs.GetInt("bestSkor")+"\n"+PlayerPrefs.GetString("bestSkorId");
        orta.GetComponent<Button>().interactable = false;
        zor.GetComponent<Button>().interactable = false;
        if (PlayerPrefs.GetInt("bestSkor") > 200)
        {
            orta.GetComponent<Button>().interactable = true;
            ortaKilit.SetActive(false);
        }
        if (PlayerPrefs.GetInt("bestSkor") > 1000)
        {
            zor.GetComponent<Button>().interactable = true;
            zorKilit.SetActive(false);
        }
    }
    private void Update()
    {
        Id = isim.text;
    }
    public void zorlukButon()
    {
        if (orta.GetComponent<Button>().interactable == false)
        {
            bilgilendirme.text = "'Orta' ve 'Zor' zorluk seviyeleri kilitlidir.\n'Zor' veya 'Orta' seviyede oynamak istiyorsanız eğer:\nLütfen önce 'Kolay' seviyede kendinizi kanıtlayınız.";
        }
        else if (zor.GetComponent<Button>().interactable == false)
        {
            bilgilendirme.text = "'Zor' zorluk seviyesi kilitlidir.\n'Zor' seviyede oynamak istiyorsanız eğer:\nLütfen önce 'Orta' seviyede kendinizi kanıtlayınız.";
        }
        if (sayac % 2 == 0)
        {
            kolay.SetActive(true);
            orta.SetActive(true);
            zor.SetActive(true);
        }
        else
        {
            Kaybol();
            bilgilendirme.text = "";
        }
        sayac++;
    }
    public void OynaButon()
    {
        if(Id == "")
        {
            bilgilendirme.text = "Lütfen isim giriniz..";
        }
        else
        {
            PlayerPrefs.SetString("Id", Id);
            SceneManager.LoadScene("Survivor");
        }
    }
    public void KolayButon()
    {
        bilgilendirme.text = "Oyunun zorluğu senin için önemli değil sen kendini geliştirmek için burdasın";
        sayac++;
        Kaybol();
        PlayerPrefs.SetInt("zorlukHiz", 10);
        PlayerPrefs.SetInt("zorlukCan", 5);
    }
    public void OrtaButon()
    {
        bilgilendirme.text = "Oyunda zombileri avlarken diğer yandan da oyunu incelemek kendi halinde takılmak istiyorsun";
        sayac++;
        Kaybol();
        PlayerPrefs.SetInt("zorlukHiz", 15);
        PlayerPrefs.SetInt("zorlukCan", 10);
    }
    public void ZorButon()
    {
        bilgilendirme.text = "Rekabetçi birisin Zorlukların üstesinden gelmek tam senlik";
        sayac++;
        Kaybol();
        PlayerPrefs.SetInt("zorlukHiz", 20);
        PlayerPrefs.SetInt("zorlukCan", 15);
    }
    public void Oynanıs()
    {
        Kaybol();
        bilgilendirme.text = "Hareket Tuşları: W,A,S,D \nAteş Etme: Mouse sol tık \nHarita Açma/Kapama: 'M' \nSilahı Açma/Kapama: 'R'\nÇıkmak için:'Q'";
    }
    void Kaybol()
    {
        kolay.SetActive(false);
        orta.SetActive(false);
        zor.SetActive(false);
    }
    public void BilgilendirmeTemizle()
    {
        bilgilendirme.text = "";
    }
    public void KayıtSilButon()
    {
        PlayerPrefs.DeleteKey("bestSkor");
        PlayerPrefs.DeleteKey("bestSkorId");
        Skor.text = "En Yüksek Skor: ";
        orta.GetComponent<Button>().interactable = false;
        zor.GetComponent<Button>().interactable = false;
        ortaKilit.SetActive(true);
        zorKilit.SetActive(true);
        if (PlayerPrefs.GetInt("bestSkor") > 200)
        {
            orta.GetComponent<Button>().interactable = true;
            ortaKilit.SetActive(false);
        }
        if (PlayerPrefs.GetInt("bestSkor") > 1000)
        {
            zor.GetComponent<Button>().interactable = true;
            zorKilit.SetActive(false);
        }
    }
    public void OyunuKapat()
    {
        Application.Quit();
    }
}
