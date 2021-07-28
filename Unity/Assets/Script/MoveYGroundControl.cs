using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYGroundControl : MonoBehaviour
{
    public float minY, maxY; //최대 y, 최소 y값

    public float moveSpeed; //움직이는 속도

    public int sign; //1이면 위로 움직임, -1이면 하면 아래로 움직임

    void Update()
    {
        if (Option.optionFlag && !StageClear.CLR)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime * sign, 0); //Y값 변경

            if (transform.position.y <= minY ||
                transform.position.y >= maxY) //최대값에 도달하거나, 최소값에 도달하면 방향 바뀜
                sign *= -1;
        }
    }
}
