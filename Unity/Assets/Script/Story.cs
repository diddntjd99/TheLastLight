using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public GameObject c;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //게임 중 화면이 꺼지지 않게 해줌
        Screen.SetResolution(1280, 720, true); //해상도를 1280*720으로 고정시켜줌
        Application.runInBackground = true; //마우스가 게임 밖에 있어도 게임이 정상 실행되게 해줌
    }

    void Start()
    {
        //this.camera_position_offset = new Vector3(0, 0, -10);
    }

    void Update()
    {
        c.transform.position = c.transform.position + new Vector3(1, 0, 0) * Time.deltaTime;
        if (c.transform.position.x > 86 || Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainScenes"); //메인 씬 불러오기
            SceneControl.currentScene = 1;
        }
    }
}
