using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    Rigidbody fizik;
    public int hiz;
    public int sayac;
    public Text skorsayac;
    public Text oyunBitti;
    public int obje;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");
        //Debug.Log("yatay = " + yatay + "    dikey = " + dikey);
        Vector3 vec = new Vector3(yatay, 0, dikey);

        fizik.AddForce(vec*hiz);

    }
    void OnTriggerEnter(Collider other)//tek dokunusta tepkı verıyor/stay olursa semas surdugu surece / exit temastan cıktıgında tepkı verıyor
    {
        if (other.gameObject.tag == "engel")
        {
            other.gameObject.SetActive(false);
            sayac++;
            skorsayac.text = "Skor = "+sayac;
            if (sayac == obje)
            {
                oyunBitti.text = "Oyun bitti";
            }
        }
        
    }
}
