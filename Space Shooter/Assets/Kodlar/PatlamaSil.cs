using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaSil : MonoBehaviour
{
    public int silmeZamani;
    void Start()
    {
        Destroy(gameObject, silmeZamani);
    }

}
