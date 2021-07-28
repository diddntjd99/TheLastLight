using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject go_UI;
    [SerializeField] GameObject clear_Light;
    [SerializeField] Rigidbody playerRD;

    public void ShowClearUI()
    {
        PlayerMoveControl.canMove = false;//클리어시 플레이어 못움직이게
        J_PlayerMoveControl.canMove = false;
        H_PlayerMoveControl.canMove = false;
        playerRD.isKinematic = true;//클리어시 관성이 있으므로 물리법칙 끄는거
        go_UI.SetActive(true);
        clear_Light.SetActive(true);//클리어시 맵전체 밝히는 빛
        FireGaugeControl.CLR_Gauge = false;
    }
}