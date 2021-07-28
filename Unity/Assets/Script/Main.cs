using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject helpUI;
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //게임 중 화면이 꺼지지 않게 해줌
        Screen.SetResolution(1280, 720, true); //해상도를 1280*720으로 고정시켜줌
        Application.runInBackground = true; //마우스가 게임 밖에 있어도 게임이 정상 실행되게 해줌
    }
    public void startButton()
    {
        SoundManager.instanse.playSE("button"); //효과음 재생
        SceneManager.LoadScene("ListScenes"); //스테이지 목록 씬 불러오기
        SceneControl.currentScene = 2;
    }
    public void helpButton()
    {
        SoundManager.instanse.playSE("button");
        helpUI.SetActive(true);
    }
    public void closeButton()
    {
        SoundManager.instanse.playSE("button");
        helpUI.SetActive(false);
    }
    public void exitButton()
    {
        SoundManager.instanse.playSE("button");
        Application.Quit();
    }
}
