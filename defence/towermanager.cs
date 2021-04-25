using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towermanager : MonoBehaviour
{ //타워선택
    public GameObject edge;
    private bool click;
    private GameObject selectedTower = null;
 
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ClickDetect();
        }
    }
    private void ClickDetect()
    {
        bool onHit = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            string HitObj = (hit.transform.gameObject.tag);
            if (HitObj == "TOWER")
            {
                if (selectedTower != null)
                {
                    select();
                }

                selectedTower = hit.transform.gameObject;
               select();

                onHit = true;
            }
        }

        if (onHit == false)
        {
            if (selectedTower != null)
            {
               select();
            }

            selectedTower = null;
        }

    }
    public void select()
    {

        if (click == true)
        {
            click = false;
            edge.SetActive(false);
        }
        else if (click == false)
        {
            click = true;
            edge.SetActive(true);
        }
    }
}
