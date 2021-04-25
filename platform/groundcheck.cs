using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    private move player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<move>();   
    }
void OnTriggerEnter2D(Collider2D col)
    {
        OnTriggerStay2D(col);  
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("GROUND"))
        {
            player.isground = true;
        }
        else {
            return;
        }
    }
  void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("GROUND"))
        {
            player.isground = false;
        }
    }
}
