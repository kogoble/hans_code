using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaker : MonoBehaviour
{
    public GameObject tower = null;
    
    void Start()
    {
        Vector3 basicpos = new Vector3(0,0,0);
        Instantiate(tower, basicpos, Quaternion.identity);
    }
}
