using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{//oyunun genel kontrollerinin gerceklestiği script
    public GameObject zombi;
    public GameObject gemi;
    public GameObject kazananKam;
    private float zamanSayaci;
    private float olusumSureci = 10;
    public Text puanText;
    private int puan = 0;
    public bool gemiAnim = true;
    private int hedefPuan;
    public GunDonumu gunDonumu;
    private int beklemeGun;



    void Start()
    {
        beklemeGun = Random.Range(1, 3);
        gunDonumu = GameObject.Find("Günes").GetComponent<GunDonumu>();
        if (PlayerPrefs.GetInt("zorlukCan") == 5)
        {
            hedefPuan = 300;
        }
        else if (PlayerPrefs.GetInt("zorlukCan") == 10)
        {
            hedefPuan = 1500;
        }
        else if (PlayerPrefs.GetInt("zorlukCan") == 15)
        {
            hedefPuan = 3000;
        }
        zamanSayaci = olusumSureci;

    }
    private void LateUpdate()
    {
        if (puan > hedefPuan && gemiAnim && gunDonumu.isaretGun > beklemeGun)
        {
            kazananKam.SetActive(true);
            gemi.SetActive(true);
            gemi.GetComponent<Animation>().Play("ship");
            StartCoroutine(gemiAnimSayac());
        }
        
    }
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci < 0)
            {
                Vector3 pos = new Vector3(Random.Range(311, 714), 26, Random.Range(712, 323));
                Instantiate(zombi, pos, Quaternion.identity);
                zamanSayaci = olusumSureci;
            }
    }
    public void puanArttir(int p)
    {
        puan += p;
        puanText.text = "Puan :" + puan;
    }
    public void oyunBitti()
    {
        PlayerPrefs.SetInt("puan", puan);
        SceneManager.LoadScene("OyunBitti");
    }
    public void oyunBittiWin()
    {
        PlayerPrefs.SetInt("puan", puan);
        if (PlayerPrefs.GetInt("puan") > PlayerPrefs.GetInt("bestSkor"))
        {
            PlayerPrefs.SetInt("bestSkor", puan);
            PlayerPrefs.SetString("bestSkorId", PlayerPrefs.GetString("Id"));
        }
        SceneManager.LoadScene("OyunWin");
    }
    IEnumerator gemiAnimSayac()
    {
        yield return new WaitForSeconds(15);
        kazananKam.SetActive(false);
        gemiAnim = false;
    }
}
