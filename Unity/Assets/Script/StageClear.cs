using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public static bool CLR = false;//클리어조건 확인
    [SerializeField] StageManager SM;
    void Update()
    {
        if (CLR == true && Input.GetKey(KeyCode.UpArrow))//클리어 조건 만족 후 윗방향키
        {
            SM.ShowClearUI();//클리어UI함수 호출

            if (SceneControl.currentScene == 3) //스테이지 1 클리어 시 true
                SceneControl.s2 = true;
            if (SceneControl.currentScene == 4)
                SceneControl.s3 = true;
            if (SceneControl.currentScene == 5)
                SceneControl.s4 = true;
            if (SceneControl.currentScene == 6)
                SceneControl.s5 = true;
            if (SceneControl.currentScene == 7)
                SceneControl.s6 = true;
            if (SceneControl.currentScene == 8)
            {
                SceneControl.s7 = true;
                SceneManager.LoadScene("EndingScenes"); //메인 씬 불러오기
            }
        }
    }

    public void exitButton()
    {
        SoundManager.instanse.playSE("button");
        SceneManager.LoadScene("ListScenes"); //스테이지 목록 씬 불러오기
        SceneControl.currentScene = 2;
    }

    public void nextButton()
    {
        SoundManager.instanse.playSE("button");
        SceneControl.currentScene += 1;
        SceneManager.LoadScene(SceneControl.currentScene); //다음 스테이지로
    }
}