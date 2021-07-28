using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomPut : MonoBehaviour
{
    public GameObject item;
    void Start()
    {
        var random = Random.value * 100; // Random.value는 0.0 ~ 1.1사이의 수 골라줌 -> 100%로 환산
        if (random < 50)
            item.SetActive(true); //50퍼센트 확률로 아이템 활성화
        else
            item.SetActive(false); //50퍼센트 확률로 아이템 비활성화
    }
}
