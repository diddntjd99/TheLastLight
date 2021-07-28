using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXGroundControl : MonoBehaviour
{
    public float minX, maxX; //최대 x, 최소 x값

    public float moveSpeed; //움직이는 속도

    public int sign; //-1이면 왼쪽으로 움직임, 1이면 오른쪽으로 움직임

    void Update()
    {
        if (Option.optionFlag && !StageClear.CLR)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0); //x값 변경

            if (transform.position.x <= minX ||
                transform.position.x >= maxX) //최대값에 도달하거나, 최소값에 도달하면 방향 바뀜
                sign *= -1;
        }
    }
}
