using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
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

        transform.localRotation=Quaternion.AngleAxis(-camPos.y,Vector3.right);
        oyuncu.transform.localRotation = Quaternion.AngleAxis(camPos.x, oyuncu.transform.up);
    }
}
