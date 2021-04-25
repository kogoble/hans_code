using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public int damage;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = direction.normalized;
        float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed);
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ENEMY") {
            col.gameObject.GetComponent<enemy1>().Hit(damage);
            gameObject.SetActive(false);
        }
    }
}
