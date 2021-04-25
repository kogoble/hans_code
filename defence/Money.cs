using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private Text money;
    public int havemoney;

    private float stack=1;
    private float time;
    void Start()
    {
        havemoney += 30;
        money = GetComponentInChildren<Text>();
        updatemoney();
    }
    void Update()
    {
            if (time <= 0)
            {
                time = stack;
                havemoney += 1;
            updatemoney();
            }
        time -= Time.deltaTime;
    }
    public void Changemoney(int value) {
        havemoney += value;
        if (havemoney < 0) {
            havemoney = 0;
        }
        updatemoney();
    }
    public int amount() {
        return havemoney;
    }

    void updatemoney() {
        money.text = havemoney.ToString();
    }

}
