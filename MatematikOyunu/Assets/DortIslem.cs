using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DortIslem : MonoBehaviour
{
    public UnityEngine.UI.Text ilkSayi, ikinciSayi,islem,cevap,sonuc;
    public UnityEngine.UI.InputField sonucInput;
    int sayi1, sayi2, islemIsareti;
    int islemSonucu;

    
    // Start is called before the first frame update
    void Start()
    {
        YeniSoru();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CevapKontrol()
    {
        if (int.Parse(cevap.text) == islemSonucu)
        {
            sonuc.text = "DOGRU";
        }
        else
        {
            sonuc.text = "YANLIS";
        }
    }
    public void YeniSoru()
    {
        cevap.text = "";
        sonucInput.text = "";
        sayi1 = Random.Range(1, 10);
        sayi2 = Random.Range(1, 10);
        islemIsareti = Random.Range(1, 4);
        switch (islemIsareti)
        {
            case 1:
                islem.text = "+";
                islemSonucu = sayi1 + sayi2;
                break;
            case 2:
                islem.text = "-";
                islemSonucu = sayi1 - sayi2;
                break;
            case 3:
                islem.text = "*";
                islemSonucu = sayi1 * sayi2;
                break;
            case 4:
                islem.text = "/";
                islemSonucu = sayi1 / sayi2;
                break;
            }
        ilkSayi.text = sayi1 + "";
        ikinciSayi.text = sayi2 + "";

        }
    }
