using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cikisKontrol : MonoBehaviour
{//oyundan cıkmak isteyen oyuncuya bu seçeneği sunan script
    public GameObject anaSayfa;
    public GameObject oyundanCik;
    public GameObject oyuncu;
    int cikisSay = 0;

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (cikisSay % 2 == 0)
            {
                oyuncu.SetActive(false);
                anaSayfa.SetActive(true);
                oyundanCik.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (cikisSay % 2 == 1)
            {
                oyuncu.SetActive(true);
                Cursor.visible = false;
                anaSayfa.SetActive(false);
                oyundanCik.SetActive(false);
            }
            cikisSay++;
        }
    }
}
