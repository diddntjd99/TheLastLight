using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_keyTrapControl : MonoBehaviour
{
    public GameObject trap;

    void OnTriggerEnter(Collider other) //통과하면 실행되는 함수
    {
        if (other.gameObject.tag == "Player") // 키에 닿은 태그가 플레이어일 때 참
        {
            Destroy(trap); //Trap을 없애고 새로운 길 open
        }

        Destroy(this); // 키 파괴
    }
}
