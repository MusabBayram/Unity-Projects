using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fareiletisim : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Text text;
   void OnMouseDown()
    {
        text.text = "Merhaba Benim Adım " + this.name;
    }
    void OnMouseDrag()
    {
        Vector2 pos = Input.mousePosition;
        Vector3 objPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y,1f));
        transform.position = objPos;
    }
}
