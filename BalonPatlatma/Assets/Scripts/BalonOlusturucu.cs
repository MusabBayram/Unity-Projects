using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonOlusturucu : MonoBehaviour
{
    public GameObject balon;
    float balonOlusturmaSuresi=1f;
    float zamanSayaci=0;
    OyunKontrol okScripti;
    // Start is called before the first frame update
    void Start()
    {
        okScripti = this.gameObject.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci < 0 && okScripti.zamanSayaci>0)
        {


            GameObject go = Instantiate(balon, new Vector3(Random.Range(-2.55f, 2.55f),-5.38f,0 ),Quaternion.Euler(0, 0, 0 )); //sayaç 0'ın altına düştüğünde balonu oluşturucak
            go.GetComponent<Rigidbody2D>().AddForce(new Vector3(10f, 50f, 0));//kuvvet
            zamanSayaci = balonOlusturmaSuresi;         //zaman sayacı tekrar eski dakikasına dönücek
        }
    }
}
