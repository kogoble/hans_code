using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : EnemyState
{ 
    //이동
    private static GM gm;
    public int waypointnumber;
    private float changeDist = 0.01f;

    void Start()
    {
           gm = FindObjectOfType<GM>();
    }
    void FixedUpdate()
    {

        if (gm.gameSet==true) {
            speed = 0;
        }
        if (waypointnumber == gm.waypoint.Length-1) {
           gm.HPstate(damage);
            Destroy(gameObject);
         
        }
        float dist = Vector2.Distance(transform.position, gm.waypoint[waypointnumber]);
        if (dist <= changeDist)
        {
            waypointnumber++;
        }
        else
        {
            movetowards(gm.waypoint[waypointnumber]);
        }
    }
    private void movetowards(Vector3 target) {
        float step = speed * Time.fixedDeltaTime;
       transform.position= Vector3.MoveTowards(transform.position, target, step);

    }

    public void Hit(float Damage) {
        health -= Damage;
        if (health <= 0)
        {//에너미를 죽이면 1원 획득 후 오브젝드 제거
            GameObject.FindGameObjectWithTag("MONEY").GetComponent<Money>().Changemoney(1);
            gm.remaining_enemy();
            Destroy(gameObject);
        }
    }
}
