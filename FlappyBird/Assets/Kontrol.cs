using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kontrol : MonoBehaviour
{
    Rigidbody2D fizik;
    public Sprite[] KusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kusAnimasyonZaman = 0;
    int puan = 0;
    public Text puanText;
    bool oyunBitti = false;
    int enYuksekPuan = 0;

    
    AudioSource []sesler;

    OyunKontrol oyunKontrol;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontroltag").GetComponent<OyunKontrol>();
        sesler = GetComponents<AudioSource>();
        enYuksekPuan = PlayerPrefs.GetInt("kayit");
        Debug.Log(enYuksekPuan);
    }

    void Update()
    {
        Animasyon();
        if (Input.GetMouseButtonDown(0) && !oyunBitti)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0,200));
            sesler[0].Play();
        }
        if (fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 30);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -25);
        }
    }
    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.2f)
        {
            kusAnimasyonZaman = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "puan")
        {
            puan++;
            puanText.text = "Skor = " + puan;
            sesler[1].Play();
        }
        if(col.gameObject.tag == "engel")
        {
            oyunBitti = true;
            sesler[2].Play();
            oyunKontrol.OyunBitti();
            GetComponent<CircleCollider2D>().enabled = false;
            if(puan > enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("kayit", enYuksekPuan);
            }
            Invoke("anaMenuyeDon", 2);
        }
    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puanKayit", puan);
        SceneManager.LoadScene("anaMenu");
    }


}
