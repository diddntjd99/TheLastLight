using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Potal : MonoBehaviour
{
    public GameObject Player;
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            //달팽이혀 위치에 플레이어가 가면 동굴 안으로 이동
            Player.transform.position = new Vector3(-117, 3, 0);
        }
    }
}
