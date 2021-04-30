using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kb_zombi : MonoBehaviour
{//zombilerin haritadaki yerlerini gosteren okun konum scripti
    public Transform zombi;
    void Update()
    {
        transform.position = new Vector3(zombi.position.x, 35, zombi.position.z);
        transform.rotation = Quaternion.Euler(zombi.eulerAngles.x+90, zombi.eulerAngles.y, zombi.eulerAngles.z);
    }
}
