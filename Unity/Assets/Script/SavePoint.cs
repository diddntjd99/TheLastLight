using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] Transform tf_OriginPos;//플레이어 스폰 위치

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tf_OriginPos.position = this.transform.position;
        }
    }

}
