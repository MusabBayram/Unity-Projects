using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform place1, place2;
    public GameObject enemy1, enemy2;

    Vector3 place1pos;
    Vector3 place2pos;
    void Start()
    {
        transform.position = new Vector3(-3.22f, 0.704f, 4.26f);
        place1pos = new Vector3(place1.position.x+0.07f, place1.position.y + 0.7f, place1.position.z + 0.8f);
        
    }

    void Update()
    {
        place2pos = new Vector3(place2.position.x + 1.8f, place2.position.y + 0.734f, place2.position.z + 0.8f);
        if (enemy1 == null)
        {
            transform.position = Vector3.Lerp(transform.position, place1pos, 0.04f);
        }
        if (enemy2 == null)
        {
            transform.position = Vector3.Lerp(transform.position, place2pos, 0.04f);
        }
    }
}
