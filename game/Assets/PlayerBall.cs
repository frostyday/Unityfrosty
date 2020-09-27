using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBall : MonoBehaviour
{
    public float jumpPower = 10;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump){
            isJump = true;
            rigid.AddForce(new Vector3(0,jumpPower,0), ForceMode.Impulse);//점프
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h,0,v), ForceMode.Impulse); //기본이동 상하좌우
    }

    void OnCollisionEnter(Collision collision) // 이벤트 함수
    {
        if(collision.gameObject.tag == "Floor") // 바닥에 닿았을때 점프 가능하게
            isJump = false;
    }

      void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item"){
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if(other.tag == "Finish"){
            if(itemCount == manager.TotalItemCount){ //모은 아이템과 전체 아이템수가 같으면
                
                if(manager.stage == 2)
                    SceneManager.LoadScene(0);
                SceneManager.LoadScene(manager.stage + 1);
            }
            else { //아니라면 재시작
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
