using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer; //애니매이션 방향 전환
    public int nextMove;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Think();

        Invoke("Think", 5);//함수 딜레이 
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //plaform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.3f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));//감지시스템
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));//바닥만 인식되게
        if(rayHit.collider == null){
            Turn();
        }
    }

    //재귀 함수
    void Think(){
        //Set Next Active
       nextMove = Random.Range(-1,2);//Range 랜덤 범위 생성 최대에 1포함 x
        //Sprite Animation
        anim.SetInteger("WalkSpeed", nextMove);
        //Flip Sprite
        if(nextMove !=0)
        spriteRenderer.flipX = nextMove == 1;
        //재귀
     float nextThinkTime = Random.Range(2f,5f);
       Invoke("Think", nextThinkTime);
    }

    void Turn()
    {
        nextMove *= -1;//방향 전환
        spriteRenderer.flipX = nextMove == 1;
        CancelInvoke(); //딜레이 멈추기
         Invoke("Think", 5);
    }
}
