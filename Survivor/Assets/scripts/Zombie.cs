using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{//zombilerin hareketlerini ve fonksiyonlarını kontrol eden script
    public GameObject kalp;
    public GameObject zombiOdun;
    private Transform hedef;
    private int zombiCan = 5;
    private int supriz;
    private float mesafe;
    private OyunKontrol OyunKont;
    Rigidbody fizik;
    int ZombiHiz = 6;


    void Start()
    {
        zombiCan = PlayerPrefs.GetInt("zorlukCan");
        ZombiHiz = PlayerPrefs.GetInt("zorlukHiz");
        OyunKont = GameObject.Find("OyunKontrol").GetComponent<OyunKontrol>();
        hedef = GameObject.FindWithTag("oyuncu").transform;
        fizik = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        mesafe = Vector3.Distance(transform.position, hedef.position);
        if (zombiCan > 0)
        {
            if (mesafe < 70 && mesafe > 2)
            {
                transform.LookAt(hedef);

                fizik.AddForce(transform.forward * ZombiHiz, ForceMode.Acceleration);

                GetComponentInChildren<Animation>().Play("Zombie_Walk_01");
            }
            else if (mesafe < 3)
            {
                GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
                transform.LookAt(hedef);
                fizik.AddForce(transform.forward * ZombiHiz, ForceMode.Acceleration);
            }
            else if (mesafe > 50)
            {
                GetComponentInChildren<Animation>().Play("Zombie_Idle_01");
            }
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        fizik.velocity = Vector2.zero;
        if (col.collider.gameObject.tag == "mermi")
        {
            zombiCan--;
            if (zombiCan == 0)
            {
                if (PlayerPrefs.GetInt("zorlukCan") == 5)
                {
                    OyunKont.puanArttir(10);
                }
                else if (PlayerPrefs.GetInt("zorlukCan") == 10)
                {
                    OyunKont.puanArttir(50);
                }
                else if (PlayerPrefs.GetInt("zorlukCan") == 15)
                {
                    OyunKont.puanArttir(100);
                }
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
                supriz = Random.Range(1, 4);
                if(supriz == 1 || supriz == 2)
                {
                    Instantiate(kalp, transform.position, Quaternion.identity);
                }
                if(supriz == 3)
                {
                    Instantiate(zombiOdun, transform.position, Quaternion.identity);
                }
            }
        }
        
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "denizTag")
        {
            Destroy(this.gameObject);
        }
    }
}
