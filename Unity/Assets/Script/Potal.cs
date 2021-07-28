using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    public Transform TransPosition;

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "Player")//태그 플레이어인지 확인
        {
            Transform ParentTransform = _col.transform;
            while (true)
            {
                if (ParentTransform.parent == null)
                    break;
                else
                    ParentTransform = ParentTransform.parent;
            }
            ParentTransform.position = TransPosition.position;
            ParentTransform.rotation = TransPosition.rotation;
        }
    }
}
