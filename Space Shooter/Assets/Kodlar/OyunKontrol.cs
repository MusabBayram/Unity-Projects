using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
   public GameObject Asteroid;
    public Vector3 randomPos;
    public Text text;
    public Text OyunBittiText;
    public Text yenidenBaslaText;
    bool oyunBittiKontrol = false;
    bool yenidenBasla = false;
    int score;
    void Start()
    {
        score = 0;
        text.text = "Score = " + score;
        StartCoroutine(olustur()); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && yenidenBasla == true)
        {
            SceneManager.LoadScene("SpaceShooter");
        }
    }
    IEnumerator olustur()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            for(int i=0; i<10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(1);
                if (oyunBittiKontrol)
                {
                    break;
                }
            }
            if (oyunBittiKontrol)
            {
                yenidenBaslaText.text = "Yeniden başlamak için 'R' tuşuna basınız";
                yenidenBasla = true;
                break;
            }
        }
        
    }
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "Score = " + score;
    }
    public void oyunBitti()
    {
        OyunBittiText.text = "Oyun Bitti";
        oyunBittiKontrol = true;
    }
}
