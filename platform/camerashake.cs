using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    public Camera cam;
    float shakesize = 0;
    private move play;
    
    void Awake()
    {
        if (cam == null)
            cam = Camera.main;
    }
    void Start()
    {
        play = GameObject.FindGameObjectWithTag("Player").GetComponent<move>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))//마우스 왼쪽을 누르고 있을 때
        {
            shake(0.02f, 0.05f);//shake함수에 값을 넣어 흔든다.
        }
        //화면 흔들기
        if (play.ondmg == true)
        {
            gameObject.GetComponent<Animation>().Play("cam_ani");
            play.ondmg = false;
        }
    }

    public void shake(float size, float length)
    {
        shakesize = size;
        InvokeRepeating("doshake", 0, 0.01f);
        Invoke("stopshake", length);
    }
    
    void doshake()
    {
        if (shakesize > 0)
        {
            Vector3 campos = cam.transform.position;//cam의 위치를 campos에 넣고
            float shakeAmtX = Random.value * shakesize*3 - shakesize;//무작위의 float값*shakesize*2-shakeseze를 shakeAmtX에 넣는다.
            float shakeAmtY = Random.value * shakesize*3 - shakesize;
            campos.x += shakeAmtX;
            campos.y += shakeAmtY;
            cam.transform.position = campos;
        }
    }
    void stopshake()
    {
        CancelInvoke("doshake");//doshake메소드를 취소한다.
        cam.transform.localPosition = Vector3.zero;//cam포지션을 상대적으로 봤을 때 0,0,0의 위치로 넣는다. 
    }
}
