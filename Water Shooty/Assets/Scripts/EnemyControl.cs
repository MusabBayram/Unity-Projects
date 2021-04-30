using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
 
    public GameObject Bullet;

    public Transform BulletPos;
    private Transform target;

    private float distance;
    float fireTime;
    int lifeCount = 100;

    public Text lifeText;
    public CharacterScript character;
    void Start()
    {
        target = GameObject.FindWithTag("PlayerTag").transform;
    }

    
    void Update()
    {
        if (!character.death)
        {
            lifeText.text = "" + lifeCount;
            if (lifeCount == 0)
            {
                lifeText.text = "";
            }

            distance = Vector3.Distance(transform.position, target.position);
            if (distance < 1.3f)
            {
                if (lifeCount > 0)
                {
                    fireTime = Random.Range(1, 20);
                    if (fireTime < 2)
                    {
                        GameObject BulletObj = Instantiate(Bullet, BulletPos.position, BulletPos.rotation);
                        BulletObj.GetComponent<Rigidbody>().AddForce(-transform.forward * 50);
                        Destroy(BulletObj.gameObject, 2);
                    }
                }
            }
        }
        
    }
  
    private void OnCollisionStay(Collision col)
    {
        if(col.collider.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            if (lifeCount > 0)
            {
                lifeCount--;
                lifeText.text = "" + lifeCount;
            }
            else
            {
                lifeText.text = "";
                GetComponent<Animation>().Play("EnemyDeath");
                Destroy(this.gameObject,2);
            }
        }
    }
}
