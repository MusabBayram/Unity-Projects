using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suAnimasyon : MonoBehaviour
{
    public Sprite[] animasyonKareleri;

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
        if (zaman > 0.03f)
        {
            spriterenderer.sprite = animasyonKareleri[kareSayac++];
            if (animasyonKareleri.Length == kareSayac)
            {
                kareSayac = 0;
            }
            zaman = 0;
        }
    }
}
