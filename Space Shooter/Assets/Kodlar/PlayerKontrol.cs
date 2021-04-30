using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float minX, maxX,minZ,maxZ,egim;
    float atesZamani = 0;
    public float atesHizi = 0;
    public GameObject Kursun;
    public Transform KursunNeredenCiksin;
    public float karakterHiz;
    AudioSource audio;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>atesZamani)
        {
            atesZamani = Time.time + atesHizi;
            Instantiate(Kursun, KursunNeredenCiksin.position, Quaternion.identity);
            audio.Play();
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        vec = new Vector3(horizontal, 0, vertical);
        
        fizik.velocity = vec*karakterHiz;

        fizik.position = new Vector3
            (
                Mathf.Clamp(fizik.position.x, minX, maxX),//x değerimizin max ve min aralığını belirledik
                0.0f,
                Mathf.Clamp(fizik.position.z, minZ, maxZ)//z değerimizin max ve min aralığını belirledik
            );
        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x*-egim);
    }
}
