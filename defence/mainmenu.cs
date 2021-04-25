using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
    }
    public void speed() {
        if (Time.timeScale!=3) { Time.timeScale = 3;
        }
        else if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }
  
   public void selectLV(int LV) {
        switch (LV) {
            case 0:
                StartCoroutine(WaitOneSecond(0));//menu
                break;
            case 1:
                StartCoroutine(WaitOneSecond(1));//LV1
                break;
            case 2:
                StartCoroutine(WaitOneSecond(2));//LV2
                break;
            case 3:
                StartCoroutine(WaitOneSecond(3));//LV3
                break;
            case 4:
                StartCoroutine(WaitOneSecond(4));//LV4
                break;
            case 5:
                StartCoroutine(WaitOneSecond(5));//LV5
                break;
        }
    }
    IEnumerator WaitOneSecond(int LV)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(LV);
    }
}
