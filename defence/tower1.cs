using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower1 : MonoBehaviour
{   //투사체를 날리는 타워

    //타워구매
    public int initialcost;
    public int upgradecost;
    public int sellvalue;
    //총알발사
    public float rangeradius;
    public float reloadtime;
    public BulletManager B_manager;
    private float elapsedtime;

    //총알 발사 위치
    public GameObject shootPos;

    private void Start()
    {
        B_manager = FindObjectOfType<BulletManager>();
    }
    private void Update()
    {
        if (elapsedtime >= reloadtime)
        {
            elapsedtime = 0;
            Collider2D[] hitcollider = Physics2D.OverlapCircleAll(transform.position, rangeradius);
            if (hitcollider.Length != 0)
            {
                float min = int.MaxValue;
                int index = -1;
                for (int i = 0; i < hitcollider.Length; i++)
                {
                    if (hitcollider[i].tag == "ENEMY")
                    {
                        float distance = Vector2.Distance(hitcollider[i].transform.position, transform.position);
                        if (distance < min)
                        {
                            index = i;
                            min = distance;
                        }
                    }
                }
                if (index == -1)
                    return;
                Transform target = hitcollider[index].transform;
                Vector2 direction = (target.position - transform.position).normalized;
                GameObject bullet = B_manager.MakeGameOBJ("bullet_Nomal");
                bullet.GetComponent<bullet>().direction = direction;
                bullet.transform.position = shootPos.transform.position;
            }
        }
        elapsedtime += Time.deltaTime;
    }
}
