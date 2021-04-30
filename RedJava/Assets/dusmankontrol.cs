using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class dusmankontrol : MonoBehaviour
{
    public int resin;
    GameObject[] gidilecekNoktalar;
    GameObject karakter;
    bool aradakiMesafeyiBirKereAl = true;
    Vector3 aradakiMesafe;
    int aradakiMesafeSayaci = 0;
    bool ilerimigerimi = true;
    RaycastHit2D ray;
    public LayerMask layermask;
    int hiz = 5;
    public Sprite onTaraf;
    public Sprite arkaTaraf;
    public GameObject kursun;
    SpriteRenderer spriterenderer;
    float atesZamani = 0;


    void Start()
    {
        gidilecekNoktalar = new GameObject[transform.childCount];
        karakter = GameObject.FindGameObjectWithTag("player");
        spriterenderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < gidilecekNoktalar.Length; i++)
        {
            gidilecekNoktalar[i] = transform.GetChild(0).gameObject;
            gidilecekNoktalar[i].transform.SetParent(transform.parent);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        beniGordumu();
        if (ray.collider.tag == "player")
        {

            hiz = 8;
            spriterenderer.sprite = onTaraf;
            atesEt();
        }
        else
        {
            hiz = 4;
            spriterenderer.sprite = arkaTaraf;
            

        }
        noktalaraGit();
    }

    void atesEt()
    {
        atesZamani += Time.deltaTime;
        if(atesZamani > Random.Range(0.2f, 1))
        {
            Instantiate(kursun, transform.position, Quaternion.identity);
            atesZamani = 0;
        }
    }


    void beniGordumu()
    {
        Vector3 rayYonum = karakter.transform.position - transform.position;
        ray = Physics2D.Raycast(transform.position, rayYonum, 1000,layermask);
        Debug.DrawLine(transform.position,ray.point,Color.magenta);

    }


    void noktalaraGit()
    {
        if (aradakiMesafeyiBirKereAl)
        {
            aradakiMesafe = (gidilecekNoktalar[aradakiMesafeSayaci].transform.position - transform.position).normalized;
            aradakiMesafeyiBirKereAl = false;

        }
        float mesafe = Vector3.Distance(transform.position, gidilecekNoktalar[aradakiMesafeSayaci].transform.position);
        transform.position += aradakiMesafe * Time.deltaTime * hiz;
        if (mesafe < 0.5f)
        {
            aradakiMesafeyiBirKereAl = true;
            if (aradakiMesafeSayaci == gidilecekNoktalar.Length - 1)
            {
                ilerimigerimi = false;
            }
            else if (aradakiMesafeSayaci == 0)
            {
                ilerimigerimi = true;
            }
            if (ilerimigerimi)
            {
                aradakiMesafeSayaci++;

            }
            else
            {
                aradakiMesafeSayaci--;

            }

        }
    }
    public Vector2 getYon()
    {
        return (karakter.transform.position - transform.position).normalized;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);
        }

    }
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(dusmankontrol))]
[System.Serializable]
class dusmankontrolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        dusmankontrol script = (dusmankontrol)target;
        EditorGUILayout.Space();
        if (GUILayout.Button("ÜRET", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject yeniObjem = new GameObject();
            yeniObjem.transform.parent = script.transform;
            yeniObjem.transform.position = script.transform.position;
            yeniObjem.name = script.transform.childCount.ToString();

        }
        EditorGUILayout.Space();
        //editörde gostermeden public acılmıyor bu sekılde gosterılıyor
        EditorGUILayout.PropertyField(serializedObject.FindProperty("layermask"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onTaraf"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("arkaTaraf"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("kursun"));
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }
}
#endif