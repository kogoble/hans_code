using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_onlyWalk : MonoBehaviour
{
    //에너미 능력치
    public float enemySpeed;
    public Vector2 enemyDirection;
    public int enemyHP;
    

    //컴포넌트 참조
    private Rigidbody2D rb;
    private Transform tr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        rb.velocity= enemySpeed * enemyDirection;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="TURN_AROUND") {
    
            if (col.transform.position.x < transform.position.x)
            {
                enemyDirection.x = 1;
                tr.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                enemyDirection.x = -1;
                tr.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
    }
