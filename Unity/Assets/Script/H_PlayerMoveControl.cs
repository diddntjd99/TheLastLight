using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerMoveControl : MonoBehaviour
{
    public static bool canMove;//움직임 여부
    [SerializeField] float jumpForce = 0f; //점프 세기
    [SerializeField] int maxJumpCount = 0; //최대 점프 횟수
    [SerializeField] Transform tf_OriginPos;  //스폰 위치 설정


    int jumpCount = 0; //현재 점프 횟수
    Rigidbody rigid = null;

    void Start()
    {
        this.transform.position = this.transform.position;
        canMove = true;//게임 시작시 움직일 수 있게 설정
        rigid = GetComponent<Rigidbody>();
    }

    void Jump() //점프 함수
    {
        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            if (jumpCount < maxJumpCount)
            {
                jumpCount++;
                rigid.velocity = Vector2.up * jumpForce;
                StageClear.CLR = false;//점프시 클리어조건 false
                SoundManager.instanse.playSE("jump");
            }
        }
    }

    void OnCollisionEnter(Collision other) //지면과 닿았을 시 다시 점프 가능
    {
        if (other.transform.tag == "Ground")
        {
            jumpCount = 0;
            StageClear.CLR = false;//클리어제단 외 다른땅밟으면 클리어조건 false
        }
        else if (other.gameObject.tag == "void")
        {
            this.transform.position = tf_OriginPos.position;//세이브 위치로 이동
            this.transform.rotation = tf_OriginPos.rotation;
        }
    }
    void Update()
    {
        Jump();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) && canMove) //오른쪽 이동
        {
            this.transform.position = this.transform.position + new Vector3(5, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && canMove) //왼쪽 이동
        {
            this.transform.position = this.transform.position + new Vector3(-5, 0, 0) * Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Firewood") //오브젝트의 태그가 Firewood일 때
        {
            if (Counter.Fire <= 2)
            {
                Counter.Fire += 1;
            }
            Destroy(other.gameObject); // 아이템 파괴
        }
        else if (other.gameObject.tag == "Coal") //오브젝트의 태그가 Coal일 때
        {
            if (Counter.C <= 2)
            {
                Counter.C += 1;
            }
            Destroy(other.gameObject); // 아이템 파괴
        }
        else if (other.gameObject.tag == "RandomStone") //오브젝트의 태그가 RandomStone일 때
        {
            if (Counter.Ran <= 2)
            {
                Counter.Ran += 1;
            }
            Destroy(other.gameObject); // 아이템 파괴
        }
        else if (other.gameObject.tag == "Double") // 태그가 더블점프인지 판단
        {
            jumpCount--;
        }
        else if (other.gameObject.tag == "Goal")
        {
            StageClear.CLR = true;//클리어 조건 true
        }
        else if (other.gameObject.tag == "void2")
        {
            this.transform.position = tf_OriginPos.position;
        }
    }
}
