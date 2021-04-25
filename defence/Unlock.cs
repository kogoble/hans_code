using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Unlock : MonoBehaviour
{
    public Button[] ColectionButtons;
    public Button[] LVButtons;
    private void Start()
    {
        int level = PlayerPrefs.GetInt("level");
        if (level>0) {
            for (int i = 0; i < level; i++)
            {
                ColectionButtons[i].interactable = true;
                LVButtons[i].interactable = true;
            }
        }
   
    }
    private void Update()
    {//test를 위한 코드 - 저장된 값 전부 초기화
        if (Input.GetKey(KeyCode.A)) {
            PlayerPrefs.DeleteAll();
        }
    }
}
