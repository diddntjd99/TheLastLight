using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrapControl : MonoBehaviour
{
    [SerializeField] Transform tf_OriginPos; //스폰 위치 설정
    public GameObject player;
    public GameObject trap;

    void OnTriggerEnter(Collider other) //통과하면 실행되는 함수
    {
        if (other.gameObject.tag == "Player") // 키에 닿은 태그가 플레이어일 때 참
        {
            Destroy(trap); //Trap을 없애고 새로운 길 open
            Destroy(this); //키 파괴
            player.transform.position = tf_OriginPos.position; //위치를 리스폰으로 변경
        }
    }
}
