using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kodlama : MonoBehaviour
{
    int minSayi = 0;
    int maxSayi = 100;
    int tahmin = 50;
    bool oyunBasladi = false;
    // Start is called before the first frame update
    void Start()
    {
         print("Benimle oyun oynamaya ne dersin. (E/H)");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!oyunBasladi) { 
        Baslangic();
        }
        else {    
        Oyun();
        }
    }
    void Baslangic()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Harika!hadi oynamaya başlayalım..");
            print("Aklından bir sayı tut ve klavyeden herhangi bir tuşa bas.");
        }else if (Input.GetKeyDown(KeyCode.H))
        {
            print("Sen bilirsin.");
        }else if (Input.anyKeyDown)
        {
            oyunBasladi = true;
            print("Aklından tuttuğun sayı " + tahmin + " mi?");
            print("Eğer daha büyükse YUKARI daha küçükse AŞAĞI doğruysa ENTER tuşuna basın");
        }
    }
    void Oyun()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            minSayi = tahmin;
            tahmin = (minSayi + maxSayi) / 2;
            print("Aklından tuttuğun sayı " + tahmin + " mi?");
            print("Eğer daha büyükse YUKARI daha küçükse AŞAĞI doğruysa ENTER tuşuna basın");
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maxSayi = tahmin;
            tahmin = (minSayi + maxSayi) / 2;
            print("Aklından tuttuğun sayı " + tahmin + " mi?");
            print("Eğer daha büyükse YUKARI daha küçükse AŞAĞI doğruysa ENTER tuşuna basın");
        }else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Yaşasın bildim beni tebrik etmeyecek misin???");
        }
    }
}

    
