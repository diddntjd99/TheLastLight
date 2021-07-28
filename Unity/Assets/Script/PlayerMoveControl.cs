using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    [SerializeField] float jumpForce = 0f; //점프 세기
    [SerializeField] int maxJumpCount = 0; //최대 점프 횟수

    public static bool canMove; //플레이어 움직임 제어
    [SerializeField] Transform tf_OriginPos; //스폰 위치 설정

    int jumpCount = 0; //현재 점프 횟수

    Rigidbody rigid = null;

    void Start()
    {
        this.transform.position = this.transform.position;
        rigid = GetComponent<Rigidbody>();

        canMove = true;
    }

    void Jump() //점프 함수
    {
        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            if (jumpCount < maxJumpCount)
            {
                jumpCount++;
                rigid.velocity = Vector2.up * jumpForce;
                StageClear.CLR = false;
                SoundManager.instanse.playSE("jump");
            }
        }
    }

    void OnCollisionEnter(Collision collision) //닿았을 때 실행되는 함수
    {
        if (collision.gameObject.tag == "Ground") //태그가 Ground일 때 참
        {
            jumpCount = 0; //점프횟수 초기화하여 다시 점프 가능
            StageClear.CLR = false;
        }
        if (collision.gameObject.tag == "Trap") //태그가 Trap일 때 참
        {
            this.transform.position = tf_OriginPos.position; //위치를 리스폰으로 변경
            this.transform.rotation = tf_OriginPos.rotation; //플레이어의 rotation을 리스폰과 일치
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.RightArrow)) //오른쪽 이동
            {
                this.transform.position = this.transform.position + new Vector3(5, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽 이동
            {
                this.transform.position = this.transform.position + new Vector3(-5, 0, 0) * Time.deltaTime;
            }
        }
    }

    void Update()
    {
        Jump();

        if (this.transform.position.y <= -10)
        {
            this.transform.position = tf_OriginPos.position; //떨어지면 리스폰 지역으로 이동
            this.transform.rotation = tf_OriginPos.rotation; //플레이어의 rotation을 리스폰과 일치
        }
    }

    void OnTriggerEnter(Collider other) //통과하면 실행되는 함수
    {
        if (other.gameObject.tag == "Goal")
        {
            StageClear.CLR = true;//클리어 조건 true
        }

        if (other.gameObject.tag == "Firewood") //오브젝트의 태그가 Firewood일 때
        {
            if (Counter.Fire <= 2)
            {
                Counter.Fire += 1;
            }
            Destroy(other.gameObject); // 아이템 파괴
        }
        if (other.gameObject.tag == "Coal") //오브젝트의 태그가 Coal일 때
        {
            if (Counter.C <= 2)
            {
                Counter.C += 1;
            }
            Destroy(other.gameObject); // 아이템 파괴
        }
        if (other.gameObject.tag == "RandomStone") //오브젝트의 태그가 RandomStone일 때
        {
            if (Counter.Ran <= 2)
            {
                Counter.Ran += 1;
            }
            Destroy(other.gameObject); // 아이템 파괴
        }
    }
}
