using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GM : MonoBehaviour
{   //현재 맵의 주소
    public int LV;
    //승리와 패배
    public GameObject win;
    public GameObject lose;
    public bool gameSet=false;
    //생성되는 적
    public GameObject enemy;
   public int count =0;
   public float time;
    public float cooltime;
    public int enemycount;
    //플레이어 체력
    public int HP;

    //체력 소모시 이벤트
    public GameObject[] slideImage;
    public Vector3[] stopPos;

    //남은 적
    private int enemy_count;
    //몬스터의 이동 루트
    public Vector3[] waypoint;
    public GameObject startPos;

    private void Start()
    {
        enemy_count = enemycount;
    }
    void Update()
    {
        //적 생성
        time -= Time.deltaTime;
            if (time <= 0)
            {
                if (count < enemycount)
                {
                    Instantiate(enemy, new Vector3(startPos.transform.position.x, startPos.transform.position.y,-1), Quaternion.identity);
                    count += 1;
                }
                time = cooltime;
            }
        //게임 결과
        if (enemy_count == 0)
        {//승리
            GameOver(true);
        }
        else if (HP <= 0)
        {//패배
            GameOver(false);
        }
    }

    public void remaining_enemy()
    {    //남아있는 적
        enemy_count--;
    }

    public void HPstate(int damage) {
        HP -= damage;
        slideImage[HP].SetActive(true);
    }
     void GameOver(bool victory)
    {
        gameSet = true;
        if (victory)
        {
            PlayerPrefs.SetInt("level",LV);
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
        }
    }

}
