using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //stop speed
        if(Input.GetButtonUp("Horizontal")){
            rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f, rigid.velocity.y );
        }
        //캐릭터 방향에 따라 축 전환
        if(Input.GetButtonDown("Horizontal")){
        spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if(Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }

    void FixedUpdate()
    {
        //move speed
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if(rigid.velocity.x > maxSpeed) //오른쪽 최대 속도
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y );
        else if(rigid.velocity.x < maxSpeed*(-1)) //왼쪽 최대 속도
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y );
    }
}
