using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class drag : MonoBehaviour
{
    public GameObject tower;
    //시작 위치
public Transform startpos;

private void OnMouseDrag()
{
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = -4;
        transform.position = mousepos;
    }
private void OnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        if (GameObject.FindGameObjectWithTag("MONEY").GetComponent<Money>().amount() >= 15 && hit.collider.tag == "TILE")
    {
        GameObject.FindGameObjectWithTag("MONEY").GetComponent<Money>().Changemoney(-15);
            Instantiate(tower,transform.position,Quaternion.identity);
            transform.position = startpos.position;
    }
    else
        {
            transform.position = startpos.position;
        }
}
}
