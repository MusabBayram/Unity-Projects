using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    float horizontal = 0, vertical = 0;
    float kafaRotUstAlt = 0, kafaRotSagSol = 0;
    int KursunHavuzSayac = 0;
    [Range(1,3)]public float hiz = 0;
    public GameObject kafaKam;
    public GameObject nisangah;
    bool atesKontrol = false;
    public GameObject[] kursunHavuzu;


    public RuntimeAnimatorController atesEdildiginde;
    public RuntimeAnimatorController atesEdilmediginde;

    public GameObject kursun;
    public Transform kursununYeri;
    Coroutine hafizaConroutine = null;

    Animator animator;
    Rigidbody fizik;
    RaycastHit hit;
    RaycastHit hitAtes;
    GameObject kamera, pos1, pos2;
    Transform iskelet;
    public Vector3 offset;

    Vector3 kameraArasiMesafe;
    void Start()
    {
        animator = GetComponent<Animator>();
        fizik = GetComponent<Rigidbody>();

        kameraArasiMesafe = kafaKam.transform.position - transform.position;
        kamera = Camera.main.gameObject;
        pos1 = kafaKam.transform.Find("Pos1").gameObject;
        pos2 = kafaKam.transform.Find("Pos2").gameObject;

        iskelet = animator.GetBoneTransform(HumanBodyBones.Chest);

        KursunHavuzu();
    }
    void KursunHavuzu()
    {
        kursunHavuzu = new GameObject[10];
        
        for (int i = 0; i < kursunHavuzu.Length; i++)
        {
            GameObject kursunObj = Instantiate(kursun);
            kursunObj.SetActive(false);
            kursunHavuzu[i] = kursunObj;
        }
    }
    public void LateUpdate()
    {
        
        if (atesKontrol)
        {
            if (hitAtes.distance > 3)
            {
                iskelet.LookAt(hitAtes.point);
                iskelet.rotation = iskelet.rotation * Quaternion.Euler(offset);
            }
        }

    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("JumpParam", true);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!atesKontrol)
            {
                hiz *= 2;
            }
            animator.SetBool("RunParam", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (!atesKontrol)
            {
                hiz /= 2;
            }
            animator.SetBool("RunParam", false);
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            nisangah.SetActive(true);
            atesKontrol = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            nisangah.SetActive(false);
            atesKontrol = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(hafizaConroutine != null)
            {
                StopCoroutine(hafizaConroutine);
            }
            animator.SetBool("FireParam", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            hafizaConroutine = StartCoroutine(AtesAnimDurdur());
            
        }

    }
    IEnumerator AtesAnimDurdur()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("FireParam", false);
    }
    void AtesEt()
    {
        kursunHavuzu[KursunHavuzSayac].SetActive(true);
        kursunHavuzu[KursunHavuzSayac].transform.position = kursununYeri.position;
        kursunHavuzu[KursunHavuzSayac].transform.rotation = kursununYeri.rotation;

        Rigidbody kursunFizik = kursunHavuzu[KursunHavuzSayac].GetComponent<Rigidbody>();
        kursunFizik.velocity = Vector2.zero;
        kursunFizik.AddForce((hitAtes.point - kursununYeri.transform.position).normalized * 1000);
        KursunHavuzSayac++;

        if (KursunHavuzSayac == kursunHavuzu.Length)
        {
            KursunHavuzSayac = 0;
        }
    }

    void FixedUpdate()
    {
        Hareket();
        if (!atesKontrol)
        {
            animator.runtimeAnimatorController = atesEdilmediginde;
            kamera.transform.position = Vector3.Lerp(kamera.transform.position, pos1.transform.position, 0.1f);
            Rotasyon();
        }
        else
        {
            animator.runtimeAnimatorController = atesEdildiginde;
            kamera.transform.position = Vector3.Lerp(kamera.transform.position, pos2.transform.position, 0.1f);
            Rotasyon2();
        }
        
        animator.SetFloat("HorizontalParam", horizontal);
        animator.SetFloat("VerticalParam", vertical);
    }
    void Hareket()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 vec = new Vector3(horizontal, 0, vertical);
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        fizik.position += vec * Time.fixedDeltaTime * hiz;
    }
    void Rotasyon()
    {
        KameraRotasyon();
        
        if (horizontal != 0 || vertical != 0)
        {
            Physics.Raycast(Vector3.zero, kafaKam.transform.GetChild(0).forward, out hit);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hit.point.x, 0, hit.point.z)), 0.4f);
            //Debug.DrawLine(Vector3.zero, hit.point);
        }
    }
    void Rotasyon2()
    {
        KameraRotasyon();
        

        Physics.Raycast(Vector3.zero, kafaKam.transform.GetChild(0).forward, out hit);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hit.point.x, 0, hit.point.z)), 0.4f);
       // Debug.DrawLine(Vector3.zero, hit.point);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        Physics.Raycast(ray, out hitAtes);
        Debug.DrawLine(ray.origin, hitAtes.point);
    }
    void KameraRotasyon()
    {
        kafaKam.transform.position = transform.position + kameraArasiMesafe;
        kafaRotUstAlt += Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * -150; //yukarı asagı fare degerı -1 ile 1 arasında deger verır
        kafaRotSagSol += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 150;
        kafaRotUstAlt = Mathf.Clamp(kafaRotUstAlt, -30, 20);
        kafaKam.transform.rotation = Quaternion.Euler(kafaRotUstAlt, kafaRotSagSol, transform.eulerAngles.z);
    }
    void JumpParamFalse()
    {
        animator.SetBool("JumpParam", false);
    }
    void JumpAddForce()
    {
        fizik.AddForce(0, Time.deltaTime * 10000, 0);
    }
}
