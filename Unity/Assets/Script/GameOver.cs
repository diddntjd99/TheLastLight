using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public Slider fireGauge; //불 게이지
    [SerializeField] Rigidbody playerRD;
    [SerializeField] GameObject GameOver_UI;

    void Update()
    {
        if(fireGauge.value <= 0)
        {
            PlayerMoveControl.canMove = false; //옵션 함수 실행 시 플레이어 못움직이게
            J_PlayerMoveControl.canMove = false;
            H_PlayerMoveControl.canMove = false;
            playerRD.isKinematic = true; //관성이 있으므로 물리법칙 끄는거
            FireGaugeControl.CLR_Gauge = false; //게이지 stop
            GameOver_UI.SetActive(true);
        }
    }

    public void ReTry()
    {
        SoundManager.instanse.playSE("button");
        SceneManager.LoadScene(SceneControl.currentScene); //현재 게임 씬 불러오기
    }

    public void ListButton()
    {
        SoundManager.instanse.playSE("button");
        SceneManager.LoadScene("ListScenes"); //스테이지 목록 씬 불러오기
        SceneControl.currentScene = 2;
    }
}
