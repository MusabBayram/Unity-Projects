using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{//merminin biryere çarptığında yokolmasını saglayan script
    private void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }
}
