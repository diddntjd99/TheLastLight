using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    [SerializeField] GameObject Option_UI;
    [SerializeField] Rigidbody playerRD;
    [SerializeField] public Slider fireGauge;
    public static bool optionFlag = true;

    public GameObject bgmOnBtn;
    public GameObject bgmOffBtn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionFlag)
            {
                OptionBtn();
                optionFlag = false;
            }
            else
            {
                Resume();
                optionFlag = true;
            }
        }
    }
    public void OptionBtn()
    {
        SoundManager.instanse.playSE("button");
        PlayerMoveControl.canMove = false; //옵션 함수 실행 시 플레이어 못움직이게
        J_PlayerMoveControl.canMove = false;
        H_PlayerMoveControl.canMove = false;
        playerRD.isKinematic = true; //관성이 있으므로 물리법칙 끄는거
        FireGaugeControl.CLR_Gauge = false; //게이지 stop

        Option_UI.SetActive(true);
        optionFlag = false;
    }
    public void Resume()
    {
        SoundManager.instanse.playSE("button");
        PlayerMoveControl.canMove = true; //resume일 때 플레이어 움직이게
        J_PlayerMoveControl.canMove = true;
        H_PlayerMoveControl.canMove = true;
        playerRD.isKinematic = false; //관성이 있으므로 물리법칙 키는 것
        FireGaugeControl.CLR_Gauge = true; //게이지 resume

        Option_UI.SetActive(false);
        optionFlag = true;
    }

    public void ListButton()
    {
        SoundManager.instanse.playSE("button");
        SceneManager.LoadScene("ListScenes"); //스테이지 목록 씬 불러오기
        SceneControl.currentScene = 2;
    }

    public void BGMOnButton() //버튼 누르면 BGM 일시정지
    {
        SoundManager.instanse.playSE("button");
        SoundManager.instanse.pauseBGM();
        bgmOnBtn.SetActive(false);
        bgmOffBtn.SetActive(true);
    }

    public void BGMOffButton() //버튼 누르면 BGM 일시정지 해제
    {
        SoundManager.instanse.playSE("button");
        SoundManager.instanse.resumeBGM();
        bgmOnBtn.SetActive(true);
        bgmOffBtn.SetActive(false);
    }
}