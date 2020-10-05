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
             rigid.velocity = new Vector2(rigid.velocity.x, 0);
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
            OnDamaged(collision.transform.position);
            
    }

    void OnDamaged(Vector2 targetPos){ //피격시 무적
        gameObject.layer = 11;

        spriteRenderer.color = new Color(1,1,1,0.4f); //플레이어 색 변경
        int dirc = transform.position.x-targetPos.x > 0 ? 1 : -1; // 피격시 해당 방향으로 튕겨나가게 함
        rigid.AddForce(new Vector2(dirc,1)*7,ForceMode2D.Impulse);
        //Animation
        anim.SetTrigger("doDamaged");
        Invoke("OffDamaged", 2); //무적시간 선택
    }

    void OffDamaged(){
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1,1,1,1);
    }
}
