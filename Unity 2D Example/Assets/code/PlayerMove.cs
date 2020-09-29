using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()//단발적인건 updata에 하는게 좋음

    {
        //jump
         if(Input.GetButtonDown("Jump") && !anim.GetBool("isJumping")){
             rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
             anim.SetBool("isJumping", true);
        }

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
        //Landing Platform
        
        if(rigid.velocity.y < 0){
               Debug.DrawRay(rigid.position, Vector3.down, new Color(0,1,0));//감지시스템

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));//바닥만 인식되게

        if(rayHit.collider != null){
            if(rayHit.distance < 0.5f)
                anim.SetBool("isJumping",false);
        }

        }
        
    
    }
}
