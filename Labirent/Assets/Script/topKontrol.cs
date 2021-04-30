using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topKontrol : MonoBehaviour
{
    public UnityEngine.UI.Text zaman, can,durum;
    public UnityEngine.UI.Button btn;
    private Rigidbody rg;
    public float hiz = 5f;
    float zamanSayaci = 30;
    int canSayaci = 10;
    bool oyunDevamke = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevamke && !oyunTamam) { 
            zamanSayaci -= Time.deltaTime;   //zamanSayaci = zamanSayaci-Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";       //+ "" integer değeri stringe çevirir.
        }
        else if(!oyunTamam)
        {
            durum.text = "OYUN TAMAMLANAMADI";
            btn.gameObject.SetActive(true);
        }
        if (zamanSayaci < 0)
        {
            oyunDevamke = false;
                
        }
       
    }
    private void FixedUpdate()
    {
        if (oyunDevamke && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            rg.AddForce(kuvvet * hiz);
        }
        else 
        { 
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;  
        if (objIsmi.Equals("Bitis"))
        {
            //print("Oyun tamamlandı..Tebrikler");
            oyunTamam = true;
            durum.text = "Oyun tamamlandı..Tebrikler";
        }
        else if(!objIsmi.Equals("labirentZemini") && !objIsmi.Equals("Zemin"))   //Labirent zeminine çarptığında candan eksilmemesi için 
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
        }
        if (canSayaci == 0) {
            oyunDevamke = false;
            durum.text = "OYUN TAMAMLANAMADI";
            btn.gameObject.SetActive(true);
        }
            
    }
}

