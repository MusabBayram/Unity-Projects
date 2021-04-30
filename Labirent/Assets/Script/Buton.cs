using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void yenidenBasla()
    {
        SceneManager.LoadScene("oyun sahnesi"); //Bu komutu kullanabilmek için(4.satir) + sahnemizin build kısmına eklenmiş olması gerek.
    }
}
