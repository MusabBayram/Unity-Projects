using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canver : MonoBehaviour
{
    public Sprite []animasyonKareleri;

    float zaman = 0;

    int kareSayac = 0;

    SpriteRenderer spriterenderer;
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman > 0.1f)
        {
            spriterenderer.sprite = animasyonKareleri[kareSayac++];
            if(animasyonKareleri.Length == kareSayac)
            {
                kareSayac = animasyonKareleri.Length-1;
            }
            zaman = 0;
        }
    }
}
