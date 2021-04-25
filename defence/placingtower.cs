using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placingtower : MonoBehaviour
{
    private GM gm;

    void Start()
    {
       gm = FindObjectOfType<GM>();
    }

   void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 7));

     

        if (Input.GetMouseButtonDown(0)) {
            //배치했으니 활성화한다.
            GetComponent<tower1>().enabled = true;
            gameObject.AddComponent<BoxCollider2D>();
            Destroy(this);
        }
    }
}
