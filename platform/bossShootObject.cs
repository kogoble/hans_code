using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShootObject : MonoBehaviour
{

    void Update()
    {
        //투사체가 날라가는 방향을 바라보는 코드
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }
}
