using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public GameObject enemy1, enemy2, enemy3;    
    public GameObject Bullet;
    public GameObject Shield;
    public GameObject Gun;

    public Image ShieldCountImage;

    public Transform BulletPos;
    public Text game;
    public Text shieldCountText;

    GameObject firePlace;
    GameObject startPlace;

    int count = 0;
    int count1 = 1;

    Animator animator;

    float fireCount = 0;
    float shieldCount = 0;

    bool shieldOk = true;
    public bool death = false;
    void Start()
    {
        animator = GetComponent<Animator>();
     
        startPlace = GameObject.FindGameObjectWithTag(""+ count);
        firePlace = GameObject.FindGameObjectWithTag(""+ count1);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, startPlace.transform.position, 0.01f);
        transform.rotation = startPlace.transform.rotation;

        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.Lerp(transform.position, firePlace.transform.position, 0.5f);
            transform.rotation = firePlace.transform.rotation;

            fireCount += 0.1f;
            if (fireCount > 0.3f)
            {
                GameObject BulletObj = Instantiate(Bullet, BulletPos.position, BulletPos.rotation);
                BulletObj.GetComponent<Rigidbody>().AddForce(transform.forward * 50);
                Destroy(BulletObj.gameObject, 2);
                fireCount = 0;
            }
            
            if (shieldOk)
            {
                shieldCount += 0.1f;
                shieldCountText.enabled = true;
                ShieldCountImage.fillAmount = shieldCount / 5f;
            }
            else
            {
                shieldCount -= 0.03f;
                shieldCountText.enabled = true;
                ShieldCountImage.fillAmount = shieldCount / 5f;
            }
            if(shieldCount <= 0)
            {
                shieldCountText.enabled = false;
                shieldCount = 0;
                shieldOk = true;
                Shield.SetActive(false);
            }
            if (shieldCount >= 5)
            {
                Shield.SetActive(true);
                shieldOk = false;
            }
        }
        else if(animator.GetBool("LoseParam"))
        {
            transform.position = Vector3.Lerp(transform.position, firePlace.transform.position, 0.5f);
            transform.rotation = firePlace.transform.rotation;
        }
        else
        {
            shieldCount -= 0.03f;
            shieldCountText.enabled = true;
            ShieldCountImage.fillAmount = shieldCount / 5f;
            if (shieldCount <= 0)
            {
                shieldCountText.enabled = false;
                shieldCount = 0;
                shieldOk = true;
                Shield.SetActive(false);
            }
            transform.position = Vector3.Lerp(transform.position, startPlace.transform.position, 0.4f);
            transform.rotation = startPlace.transform.rotation;
        }
        if(count < 1)
        {
            if (enemy1 == null)
            {
                count += 2;
                count1 = count + 1;
                startPlace = GameObject.FindGameObjectWithTag("" + count);
                firePlace = GameObject.FindGameObjectWithTag("" + count1);
            }
        }
        else if (count < 3)
        {
            
            if (enemy2 == null)
            {
                count += 2;
                count1 = count + 1;
                startPlace = GameObject.FindGameObjectWithTag("" + count);
                firePlace = GameObject.FindGameObjectWithTag("" + count1);
            }
        }
        else if (count < 5)
        {
            if (enemy3 == null)
            {
                Destroy(Gun);
                animator.SetBool("WinParam", true);
                game.text = "You Win";

            }
        }

    }
    private void OnCollisionStay(Collision col)
    {
        if (shieldOk == true)
        {
            if (col.collider.gameObject.tag == "Bullet")
            {
                death = true;
                Destroy(col.gameObject);
                Destroy(Gun);

                animator.SetBool("LoseParam", true);
               
                game.text = "You Lose";

            }
        }
    }
}
