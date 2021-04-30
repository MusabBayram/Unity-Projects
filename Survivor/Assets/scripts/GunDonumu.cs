using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunDonumu : MonoBehaviour
{//günes ve ayın dönümlerini ayarlayan script
    public Material skyboxGunduz;
    public Material skyboxGece;
    public Material skyboxAksam;
    public Material skyboxSabah;
    public OyuncuKontrol oyuncu;
    public Text kacGunText;
    float sayac = 0;
    public int isaretGun = 0;
    public int kacGun = 0;
    void Start()
    {
        RenderSettings.skybox = skyboxGunduz;
    }

    void Update()
    {
        sayac += Time.deltaTime;
        if (sayac > 2 && sayac < 3)
        {
            oyuncu.bilgilendirText.text = "";
        }
        transform.RotateAround(new Vector3(500, 0, 500), Vector3.right, 2f * Time.deltaTime);
        if (sayac > 0 && sayac <=40 || sayac > 160)
        {
            RenderSettings.skybox = skyboxGunduz;
        }
        if (sayac > 40 && sayac <=60)
        {
            RenderSettings.skybox = skyboxAksam;
        }
        if (sayac > 60 && sayac <= 140)
        {
            RenderSettings.skybox = skyboxGece;
        }
        if (sayac > 135 && sayac <= 155)
        {
            RenderSettings.skybox = skyboxSabah;
        }
        if(sayac > 178)
        {
            sayac = 0;
            oyuncu.canDeger -= 10;
            oyuncu.canImag.fillAmount = oyuncu.canDeger / 100f;
            oyuncu.bilgilendirText.text = "Açlıktan canınız azaldı";
            oyuncu.canImag.color = Color.Lerp(Color.red, Color.green, oyuncu.canDeger / 100f);
            kacGun++;
            kacGunText.text = "Adada Geçirilen Gün: " + kacGun;
            if (oyuncu.isaretVerildi)
            {
                isaretGun++;
            }
        }
    }
    
}
