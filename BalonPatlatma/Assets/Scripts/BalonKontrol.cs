using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonKontrol : MonoBehaviour
{
    public GameObject patlama;
    OyunKontrol oyunKontrolScripti;
    void Start()
    {
        oyunKontrolScripti = GameObject.Find("_Scripts").GetComponent<OyunKontrol>();
    }
    private void OnMouseDown()
    {
        GameObject go = Instantiate(patlama, transform.position, transform.rotation)as GameObject;  
        Destroy(this.gameObject);//Scriptin bağlı olduğu oyun objesini yok et
        Destroy(go,0.333f);
        oyunKontrolScripti.BalonEkle();
    }
}
