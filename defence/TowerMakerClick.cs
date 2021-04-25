using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerMakerClick : MonoBehaviour
{
    private bool isclicked = false;

    public GameObject alpha150 = null;
    private GameObject createalpha = null;
    public GameObject realTower = null;

    //타워 설치 가능여부
    public GameObject green = null;
    public GameObject red = null;
    //타워 위치
    //private bool cancreate= false;
    
    
    private void OnMouseDown()
    {
        isclicked = true;
        createalpha = Instantiate(alpha150, transform);
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = -3;
        createalpha.transform.position = mousepos;
    }

    private void OnMouseDrag()
    {
        if (isclicked == true)
        {
            // 마우스따라 반투명 캐릭터가 움직임
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = -4;
            createalpha.transform.position = mousepos;


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider.tag == "TILE")
            {
                red.SetActive(false);
                green.SetActive(true);
                green.transform.position = mousepos;
               
            }
            else if (hit.collider.tag != "TILE")
            {
                green.SetActive(false);
                red.SetActive(true);
                red.transform.position = mousepos;
               
            }
        }
    }

    private void OnMouseUp()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        if (GameObject.FindGameObjectWithTag("MONEY").GetComponent<Money>().amount() >= 15&& hit.collider.tag == "TILE")
        {
                GameObject.FindGameObjectWithTag("MONEY").GetComponent<Money>().Changemoney(-15);
                Instantiate(realTower, new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y,2), Quaternion.identity);
                isclicked = false;
                Destroy(createalpha);
        }
        else
        {
            isclicked = false;
            Destroy(createalpha);
        }


        green.SetActive(false);
        red.SetActive(false);
    }
}
