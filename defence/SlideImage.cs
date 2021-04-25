using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlideImage : MonoBehaviour
{
    public GM gm;
    public Vector3[] stopPos;
    public int hp;
    public int speed;
    void Start()
    {
        gm = FindObjectOfType<GM>();
    }

  //왼쪽으로 이동하다 가운데에서 잠시 멈춘 뒤 다시 왼쪽으로 이동하게 하자.
    void Update()
    {
        if (gm.HP == hp) {
       
            if (transform.position.x <= stopPos[0].x)
            {
                Invoke("imageSlideToLeft", 1f);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, stopPos[0], speed*Time.deltaTime);

            }
        }
    }

    public void imageSlideToLeft() {
        transform.position = Vector3.MoveTowards(transform.position, stopPos[1], speed * Time.deltaTime);
    }
}
