using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour // 점수와 스테이지 hp 관리 
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;

    public int health;
    public PlayerMove player;

    public GameObject[] Stages;

    public Image[] UIheahth;
    public Text UIPoint;
    public Text UIStage;

    public GameObject UIRestartBtn;

    // Start is called before the first frame update  
    void Update()//점수는 update에 
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }



    public void NextStage()
    {
        //스테이지 변경
        if(stageIndex < Stages.Length-1){
        Stages[stageIndex].SetActive(false);
        stageIndex++;
        Stages[stageIndex].SetActive(true);
         PlayerReposition();

         UIStage.text = "STAGE " + (stageIndex+1);//인덱스값이라 +1;
        }
        else{ // 게임 클리어
            Time.timeScale = 0;
            Debug.Log("게임 클리어!");

             UIRestartBtn.SetActive(true); 
             Text btnText =  UIRestartBtn.GetComponentInChildren<Text>();
             btnText.text = "Game Clear";
             UIRestartBtn.SetActive(true);
        }

        //점수
        totalPoint += stagePoint;
        stagePoint = 0;
    }


    public void HealthDown(){
        if(health > 1){
         health--;
         UIheahth[health].color = new Color(1,0,0,0.4f);
        }
         else{

        UIheahth[0].color = new Color(1,0,0,0.4f);
        //플레이어 사망
        player.OnDie();  

        Debug.Log("죽었습니다!");
        UIRestartBtn.SetActive(true); //겜 끝나면 재시작버튼 활성화
         }
    }
    // Update is called once per fram
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            if(health > 1)
                PlayerReposition();

        }
        HealthDown();

        //떨어졌을때 원래 위치로
        collision.attachedRigidbody.velocity = Vector2.zero;
        collision.transform.position = new Vector3(-5,1,-1);
    }

    void PlayerReposition(){
        player.transform.position = new Vector3(0,0,-1); 
        player.VelocityZero();

    }

    public void Restart(){

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
