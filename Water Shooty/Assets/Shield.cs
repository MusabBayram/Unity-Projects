using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldPos;
    void Update()
    {
        transform.position = ShieldPos.transform.position;
        transform.rotation = ShieldPos.transform.rotation;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Debug.Log("kalkana çarptı");
        }
    }
}
