using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    private float hiz = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        x *= Time.deltaTime * hiz;      //
        y *= Time.deltaTime * hiz;      //x ve y hareketlerini yumuşatmak için kullandık.

        transform.Translate(x, 0f, y);  //Objemizi hareket ettirir.
    }
}
float hassasiyet = 5f;
float yumusaklık = 2f;

GameObject oyuncu;

Vector2 gecisPos;
Vector2 camPos;
// Start is called before the first frame update
void Start()
{
    oyuncu = transform.parent.gameObject;
}

// Update is called once per frame
void Update()
{
    Vector2 farePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    farePos = Vector2.Scale(farePos, new Vector2(hassasiyet * yumusaklık, hassasiyet * yumusaklık));
    gecisPos.x = Mathf.Lerp(gecisPos.x, farePos.x, 1f / yumusaklık);//Belirli bir boktadan diğer bir noktaya geçişi sağlıyor.
    gecisPos.y = Mathf.Lerp(gecisPos.y, farePos.y, 1f / yumusaklık);
    camPos += gecisPos;

    transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
    oyuncu.transform.localRotation = Quaternion.AngleAxis(camPos.x, oyuncu.transform.up);
}
