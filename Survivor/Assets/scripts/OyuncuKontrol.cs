using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OyuncuKontrol : MonoBehaviour
{//oyuncuyla ilgili tüm kontrollerin sağlandığı script
    public Text bilgilendirText;
    public Text odunSayText;
    public Image canImag;
    public Transform mermiPos;
    public OyunKontrol OyunKont;
    public GameObject mermi;
    public GameObject patlama;
    public GameObject haritaCam;
    public GameObject silah;
    public GameObject isaretAlevi;
    public float canDeger = 100;
    float atisZaman;
    int odunSay = 0;
    bool harita = false;
    bool gun = true;
    bool gemiSur = false;
    bool odunTopla = false;
    public bool isaretVerildi = false;
    
    void Start()
    {
        haritaCam.SetActive(false);
    }
    void Update()
    {
        atisZaman += Time.deltaTime;
        if(atisZaman > 0.2f && gun)
        {
            atisZaman = 0;
            if (Input.GetMouseButton(0))
            {
                GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;
                GameObject goPatlama = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
                go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 30;
                Destroy(go.gameObject, 2);
                Destroy(goPatlama.gameObject, 2);
            }
        }
        if (Input.GetKeyDown("m"))
        {
            if (!harita)
            {
                haritaCam.SetActive(true);
                harita = true;
            }
            else if (harita)
            {
                haritaCam.SetActive(false);
                harita = false;
            }
        }
        if (Input.GetKeyDown("r"))
        {
            if (!gun)
            {
                silah.SetActive(true);
                gun = true;
            }
            else if (gun)
            {
                silah.SetActive(false);
                gun = false;
            }
        }
        if (Input.GetKeyDown("e") && gemiSur == true)
        {
            OyunKont.oyunBittiWin();
        }
        if (Input.GetKeyDown("e") && odunTopla==true)
        {
            odunSay++;
            odunSayText.text = odunSay + "/20";
            bilgilendirText.text = "";
            if (odunSay == 20)
            {
                bilgilendirText.text = "işaret alevini yakmak için yüksekte kayalıkların ortasında bir yer bul.\nMesajı silmek için 'Z' ye bas.";
            }
            odunTopla = false;
        }
        if (Input.GetKeyDown("z"))
        {
            bilgilendirText.text = "";
        }
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "zombi")
        {
            if (OyunKont.gemiAnim == true)
            {
                canDeger -= 10;
                if (canDeger <= 0)
                {
                    OyunKont.oyunBitti();
                }
                canImag.fillAmount = canDeger / 100f;
                canImag.color = Color.Lerp(Color.red, Color.green, canDeger / 100f);
            }
        }
        
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "odunTag")
        {
            bilgilendirText.text = "";
            odunTopla = false;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "denizTag")
        {
            canDeger -= 0.1f;
            bilgilendirText.text = "Boğuluyorsunuz..";
            if (canDeger <= 0)
            {
                OyunKont.oyunBitti();
            }
            canImag.fillAmount = canDeger / 100f;
            canImag.color = Color.Lerp(Color.red, Color.green, canDeger / 100f);
        }
        if (col.gameObject.tag == "boğulmaKontrolTag")
        {
            bilgilendirText.text = "";
        }
        if (col.gameObject.tag == "odunTag")
        {
            bilgilendirText.text = "Topla (E)";
            if (Input.GetKeyDown("e"))
            {
                odunTopla = true;
                Destroy(col.gameObject);
            }
        }

        if (odunSay > 19)
        {
            if (col.gameObject.tag == "işaretAleviniYakTag")
            {
                bilgilendirText.text = "İşaret Alevini Yak (E)";
                if (Input.GetKeyDown("e"))
                {
                    isaretAlevi.SetActive(true);
                    isaretVerildi = true;
                    bilgilendirText.text = "";
                    Destroy(col.gameObject);
                }
                    
            }
            if (col.gameObject.tag == "İşaretAleviTag")
            {
                canDeger -= 0.1f;
                bilgilendirText.text = "Yanıyorsunuz..";
                if (canDeger <= 0)
                {
                    OyunKont.oyunBitti();
                }
                canImag.fillAmount = canDeger / 100f;
                canImag.color = Color.Lerp(Color.red, Color.green, canDeger / 100f);
            }
            if (col.gameObject.tag == "işaretAleviKontrolTag")
            {
                bilgilendirText.text = "";
            }
        }
        

    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "kalp")
        {
            Destroy(col.gameObject);
            if (canDeger < 100)
            {
                canDeger += 10;
            }
            canImag.fillAmount = canDeger / 100f;
            canImag.color = Color.Lerp(Color.red, Color.green, canDeger / 100f);
        }
        if(col.gameObject.tag == "zombiOdunTag")
        {
            Destroy(col.gameObject);
            odunSay++;
            odunSayText.text = odunSay + "/20";
            if (odunSay == 20)
            {
                bilgilendirText.text = "işaret alevini yakmak için yüksekte kayalıkların ortasında bir yer bul.\nMesajı silmek için 'Z' ye bas.";
            }
        }
        if (col.gameObject.tag == "gemiTag")
        {
            gemiSur = true;
            bilgilendirText.text = "Sürmek için 'E' tuşuna basınız.";
        }
        else if (col.gameObject.tag == "gemiKontTag")
        {
            gemiSur = false;
            bilgilendirText.text = "";
        }
    }
    public void anaSayfaButon()
    {
        SceneManager.LoadScene("GirisEkrani");
    }
    public void OyunuKapat()
    {
        Application.Quit();
    }
}
