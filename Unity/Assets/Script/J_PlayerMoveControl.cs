using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_PlayerMoveControl : MonoBehaviour
{
    [SerializeField] float jumpForce = 0f; //점프 세기
    [SerializeField] int maxJumpCount = 0; //최대 점프 횟수
    [SerializeField] Transform tf_OriginPos;

    int jumpCount = 0; //현재 점프 횟수

    Rigidbody rigid = null;
    public static bool canMove;

    void Start()
    {
        this.transform.position = this.transform.position;
        rigid = GetComponent<Rigidbody>();
        canMove = true;
    }

    void Jump() //점프 함수
    {
        if (Input.GetKeyDown(KeyCode.Space) && (canMove == true))
        {
            if (jumpCount < maxJumpCount)
            {
                jumpCount++;
                rigid.velocity = Vector2.up * jumpForce;
                StageClear.CLR = false;//클리어 조건 false
                SoundManager.instanse.playSE("jump");
            }
        }
    }

    void OnCollisionEnter(Collision other) //닿았을 시
    {
        if (other.transform.tag == "Ground")
        {
            jumpCount = 0;
            StageClear.CLR = false;
        }
        if (other.gameObject.tag == "Trap")
        {
            this.transform.position = new Vector3(0, 1, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "Trap1")
        {
            this.transform.position = new Vector3(-33, 63, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "Trap2")
        {
            this.transform.position = new Vector3(20, 22, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "Trap3")
        {
            this.transform.position = new Vector3(3, 53, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "Trap4")
        {
            this.transform.position = new Vector3(8, 52, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "Trap5")
        {
            this.transform.position = new Vector3(-48, 20, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "Trap6")
        {
            this.transform.position = new Vector3(-48, 56, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "Trap7")
        {
            this.transform.position = new Vector3(17, 13, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "Pt")
        {
            this.transform.position = new Vector3(-1, 18, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "R1")
        {
            this.transform.position = new Vector3(30, 70, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "R2")
        {
            this.transform.position = new Vector3(19, 80, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "R3")
        {
            this.transform.position = new Vector3(30, 80, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "R4")
        {
            this.transform.position = new Vector3(9, 70, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "R5")
        {
            this.transform.position = new Vector3(9, 80, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }

        if (other.gameObject.tag == "R6")
        {
            this.transform.position = new Vector3(19, 70, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }
        if (other.gameObject.tag == "End")
        {
            this.transform.position = new Vector3(94, 26, 0);
            this.transform.rotation = tf_OriginPos.rotation;
        }

    }
    void Update()
    {

        Jump();

        if (this.transform.position.y <= -10) //떨어지면 리스폰 지역으로 이동
        {
            this.transform.position = new Vector3(0, 1, 0);
            this.transform.rotation = tf_OriginPos.rotation; //플레이어의 rotation을 리스폰과 일치
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) && (canMove == true)) //오른쪽 이동
        {
            this.transform.position = this.transform.position + new Vector3(5, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && (canMove == true)) //왼쪽 이동
        {
            this.transform.position = this.transform.position + new Vector3(-5, 0, 0) * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
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
