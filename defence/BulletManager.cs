using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{   //총알 프리팹
   public GameObject bullet_Nomal_prefab;
    public GameObject bullet_Boom_prefab;

    //생성될 총알들
    GameObject[] bullet_Nomal;
    GameObject[] bullet_Boom;

    //생성하는 총알들
    GameObject[] targetPool;

    private void Awake()
    {
        bullet_Nomal = new GameObject[50];
        bullet_Boom = new GameObject[10];
        Generate();
    }

    void Generate() {
        for (int i = 0; i < bullet_Nomal.Length; i++)
        {
            bullet_Nomal[i] = Instantiate(bullet_Nomal_prefab);
            bullet_Nomal[i].SetActive(false);
        }
        for (int i = 0; i < bullet_Boom.Length; i++)
        {
            bullet_Boom[i] = Instantiate(bullet_Boom_prefab);
            bullet_Boom[i].SetActive(false);
        }
    }

    //이제 이 함수만 호출하면 언제든 총알을 꺼내 쓸 수 있음
    public GameObject MakeGameOBJ(string type) {
        switch (type) {
            case "bullet_Nomal":
                targetPool = bullet_Nomal;
                break;
            case "bullet_Boom":
                targetPool = bullet_Boom;
                break;
        }
        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }
        return null;
    }
}
