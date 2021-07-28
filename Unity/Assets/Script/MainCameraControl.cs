using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControl : MonoBehaviour
{
    public GameObject player; // 인게임 상의 캐릭터
    Vector3 camera_position_offset; // 카메라의 위치
    Vector3 light_position_offset; // 라이트의 위치

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //게임 중 화면이 꺼지지 않게 해줌
        Screen.SetResolution(1280, 720, true); //해상도를 1280*720으로 고정시켜줌
        Application.runInBackground = true; //마우스가 게임 밖에 있어도 게임이 정상 실행되게 해줌
    }

    void Start()
    {
        //카메라와 라이트 위치를 캐릭터 위치에 설정
        this.camera_position_offset = this.transform.position - this.player.transform.position;
        this.light_position_offset = this.transform.position - this.player.transform.position;
    }

    void LateUpdate()
    {
        //카메라의 위치 변경
        Vector3 newPosition = this.transform.position; // 이동 후 위치
        newPosition.x = this.player.transform.position.x + this.camera_position_offset.x;
        newPosition.y = this.player.transform.position.y + this.camera_position_offset.y;
        this.transform.position = newPosition;

        //라이트의 위치 변경
        Vector3 newPosition2 = this.transform.position; // 이동 후 위치
        newPosition2.x = this.player.transform.position.x + this.light_position_offset.x;
        newPosition2.y = this.player.transform.position.y + this.light_position_offset.y;
        this.transform.position = newPosition2;
    }
}
