using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageList : MonoBehaviour
{
    public GameObject s2Btn; //스테이지 버튼
    public GameObject s2Lock; //Lock 걸린 스테이지 버튼
    public GameObject s3Btn;
    public GameObject s3Lock;
    public GameObject s4Btn;
    public GameObject s4Lock;
    public GameObject s5Btn;
    public GameObject s5Lock;
    public GameObject s6Btn;
    public GameObject s6Lock;

    public GameObject l;
    public GameObject r;
    public GameObject o;
    public GameObject y;
    public GameObject g;
    public GameObject b;
    public GameObject p;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //게임 중 화면이 꺼지지 않게 해줌
        Screen.SetResolution(1280, 720, true); //해상도를 1280*720으로 고정시켜줌
        Application.runInBackground = true; //마우스가 게임 밖에 있어도 게임이 정상 실행되게 해줌
    }

    void Update()
    {
        if (SceneControl.s2) //스테이지 1을 클리어 했을 때
        {
            s2Btn.SetActive(true); //스테이지 2 버튼 활성화
            s2Lock.SetActive(false);
            r.SetActive(true);
        }
        else
        {
            s2Btn.SetActive(false); //스테이지 2 Lock 버튼 비활성화
            s2Lock.SetActive(true);
            r.SetActive(false);
        }

        if (SceneControl.s3)
        {
            s3Btn.SetActive(true);
            s3Lock.SetActive(false);
            o.SetActive(true);
        }
        else
        {
            s3Btn.SetActive(false);
            s3Lock.SetActive(true);
            o.SetActive(false);
        }

        if (SceneControl.s4)
        {
            s4Btn.SetActive(true);
            s4Lock.SetActive(false);
            y.SetActive(true);
        }
        else
        {
            s4Btn.SetActive(false);
            s4Lock.SetActive(true);
            y.SetActive(false);
        }

        if (SceneControl.s5)
        {
            s5Btn.SetActive(true);
            s5Lock.SetActive(false);
            g.SetActive(true);
        }
        else
        {
            s5Btn.SetActive(false);
            s5Lock.SetActive(true);
            g.SetActive(false);
        }

        if (SceneControl.s6)
        {
            s6Btn.SetActive(true);
            s6Lock.SetActive(false);
            b.SetActive(true);
        }
        else
        {
            s6Btn.SetActive(false);
            s6Lock.SetActive(true);
            b.SetActive(false);
        }

        if (SceneControl.s7)
        {
            p.SetActive(true);
            l.SetActive(true);
        }
        else
        {
            p.SetActive(false);
            l.SetActive(false);
        }
    }

    public void homeButton()
    {
        SoundManager.instanse.playSE("button");
        SceneManager.LoadScene("MainScenes"); //메인 씬 불러오기
        SceneControl.currentScene = 1;
    }
    public void Stage1Button()
    {
        SoundManager.instanse.playSE("button");
        SceneManager.LoadScene("Stage1Scenes"); //1스테이지 씬 불러오기
        SceneControl.currentScene = 3;
    }
    public void Stage2Button()
    {
        if (SceneControl.s2)
        {
            SoundManager.instanse.playSE("button");
            SceneManager.LoadScene("Stage2Scenes"); //2스테이지 씬 불러오기
            SceneControl.currentScene = 4;
        }
    }
    public void Stage3Button()
    {
        if (SceneControl.s3)
        {
            SoundManager.instanse.playSE("button");
            SceneManager.LoadScene("Stage3Scenes"); //3스테이지 씬 불러오기
            SceneControl.currentScene = 5;
        }
    }
    public void Stage4Button()
    {
        if (SceneControl.s4)
        {
            SoundManager.instanse.playSE("button");
            SceneManager.LoadScene("Stage4Scenes"); //4스테이지 씬 불러오기
            SceneControl.currentScene = 6;
        }
    }
    public void Stage5Button()
    {
        if (SceneControl.s5)
        {
            SoundManager.instanse.playSE("button");
            SceneManager.LoadScene("Stage5Scenes"); //5스테이지 씬 불러오기
            SceneControl.currentScene = 7;
        }
    }
    public void Stage6Button()
    {
        if (SceneControl.s6)
        {
            SoundManager.instanse.playSE("button");
            SceneManager.LoadScene("Stage6Scenes"); //6스테이지 씬 불러오기
            SceneControl.currentScene = 8;
        }
    }
}
