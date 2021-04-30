using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karakterKontrol : MonoBehaviour
{

    public Sprite[] beklemeAnim;
    public Sprite[] ziplamaAnim;
    public Sprite[] yurumeAnim;
    public Text canText;
    public Text altinText;
    public Image SiyahArkaPlan;

    int altinSayaci = 0;
    int can = 50;
    int beklemeAnimSayac = 0;
    int yurumeAnimSayac = 0;

    float horizontal = 0;
    float beklemeAnimZaman = 0;
    float yurumeAnimZaman = 0;
    float siyahArkaPlanSayaci = 0;
    float anaMenuyeDonZaman = 0;


    Rigidbody2D fizik;
    SpriteRenderer spriteRenderer;

    

    
    Vector3 vec;
    Vector3 kameraSonPos;
    Vector3 kameraIlkPos;

    GameObject kamera;

    bool birKereZipla = true;
    void Start()
    {
        Time.timeScale = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        if(SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("kacinciLevel"))
        {
            PlayerPrefs.SetInt("kacinciLevel", SceneManager.GetActiveScene().buildIndex);
        }
        
        kameraIlkPos = kamera.transform.position - transform.position;

        canText.text = "CAN 100";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (birKereZipla)
            {
                fizik.AddForce(new Vector2(0, 500));
                birKereZipla = false;
            }
            
        }
    }

    void FixedUpdate()
    {
        if (can <= 0)
        {
            Time.timeScale = 0.4f;
            canText.enabled = false;
            siyahArkaPlanSayaci += 0.03f;
            SiyahArkaPlan.color = new Color(0, 0, 0, siyahArkaPlanSayaci);
            anaMenuyeDonZaman += Time.deltaTime;

            if(anaMenuyeDonZaman > 1)
            {
                SceneManager.LoadScene("AnaMenu");
            }
        }
        karakterHareket();
        Animasyon();
    }
    private void LateUpdate()
    {
        kameraKontrol();
    }
    void karakterHareket()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * 10, fizik.velocity.y, 0);
        fizik.velocity = vec;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        birKereZipla = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "kursun")
        {
            can--;
            canText.text = "CAN " + can;
        }
        if(col.gameObject.tag == "dusman")
        {
            can -= 10;
            canText.text = "CAN " + can;
        }
        if (col.gameObject.tag == "testere")
        {
            can -= 10;
            canText.text = "CAN " + can;
        }
        if(col.gameObject.tag == "levelbitsin")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (can < 90)
        {
            if(col.gameObject.tag == "canver")
            {
                
                can += 10;
                canText.text = "CAN " + can;
                col.GetComponent<BoxCollider2D>().enabled = false;
                col.GetComponent<canver>().enabled = true;
                Destroy(col.gameObject, 3);
            }
        }
        if(col.gameObject.tag == "altin")
        {
            altinSayaci++;
            altinText.text = "ALTIN 30 -" + altinSayaci;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "su")
        {
            can = 0;
        }
    }
    void kameraKontrol()
    {
        kameraSonPos = kameraIlkPos + transform.position;
        kamera.transform.position = Vector3.Lerp(kamera.transform.position, kameraSonPos, 0.08f);
    }
    void Animasyon()
    {
        if (birKereZipla)
        {
            if (horizontal == 0)
            {
                beklemeAnimZaman += Time.deltaTime;
                if (beklemeAnimZaman > 0.05f)
                {
                    spriteRenderer.sprite = beklemeAnim[beklemeAnimSayac++];
                    if (beklemeAnimSayac == beklemeAnim.Length)
                    {
                        beklemeAnimSayac = 0;
                    }
                    beklemeAnimZaman = 0;
                }

            }
            else if (horizontal > 0)
            {
                yurumeAnimZaman += Time.deltaTime;
                if (yurumeAnimZaman > 0.01f)
                {
                    spriteRenderer.sprite = yurumeAnim[yurumeAnimSayac++];
                    if (yurumeAnimSayac == yurumeAnim.Length)
                    {
                        yurumeAnimSayac = 0;
                    }
                    yurumeAnimZaman = 0;
                }
                transform.localScale = new Vector3(1, 1, 1);

            }
            else if (horizontal < 0)
            {
                yurumeAnimZaman += Time.deltaTime;
                if (yurumeAnimZaman > 0.01f)
                {
                    spriteRenderer.sprite = yurumeAnim[yurumeAnimSayac++];
                    if (yurumeAnimSayac == yurumeAnim.Length)
                    {
                        yurumeAnimSayac = 0;
                    }
                    yurumeAnimZaman = 0;
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if(fizik.velocity.y > 0)
            {
                spriteRenderer.sprite = ziplamaAnim[0];
            }
            else
            {
                spriteRenderer.sprite = ziplamaAnim[1];
            }
            if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        
    }
}
