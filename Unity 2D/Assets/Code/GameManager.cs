using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkPanel;
    public TypeEffect talk;
    public GameObject scanObject;
    public GameObject menuSet;
    public Image portraitImg;
    public Animator portraitAnim;
    public bool isAction;
    public int talkIndex;
    public Sprite prevPortrait;
    public Text questText;
    public GameObject player;


    void  Start()
    {
        GameLoad();
       questText.text = questManager.CheckeQuest();
    }

    void Update()
    {
        //Sub menu
        if(Input.GetButtonDown("Cancel")){
            if(menuSet.activeSelf)
            menuSet.SetActive(false);
            else
            menuSet.SetActive(true);
        }
    }


    public void Action(GameObject scanObj)
    {   
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        //talkPanel.SetActive(isAction);
        talkPanel.SetBool("isShow", isAction);
    }


    void Talk(int id, bool isNpc){

        int questTalkIndex = 0;
        string talkData ="";

        if(talk.isAnim){
            talk.SetMsg("");
            return;
        }
         else{
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id+questTalkIndex, talkIndex);

            }
        if(talkData == null){// 대화 끝
            isAction = false;
            talkIndex = 0; // 다른 대화를 위해 초기화
            questText.text = questManager.CheckeQuest(id);
            return;
        }

        if(isNpc){
            talk.SetMsg(talkData.Split(':')[0]);// split 배열 나누기

            portraitImg.sprite = talkManager.Getportrait(id, int.Parse(talkData.Split(':')[1]));//parse -> 문자열을 해당 타입으로 변환
            portraitImg.color = new Color(1,1,1,1);
            //애니매이션 portrait
            if(prevPortrait != portraitImg.sprite){
            portraitAnim.SetTrigger("doEffect");
            prevPortrait = portraitImg.sprite;
            }

        }
        else{
             talk.SetMsg(talkData);

             portraitImg.color = new Color(1,1,1,0);
        }

        isAction = true;
        talkIndex++;
    }

    public void GameSave(){

        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);//간단한 데이터 저장 기능 지원
        PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
        PlayerPrefs.SetFloat("QuestId",questManager.questId);
        PlayerPrefs.SetFloat("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();
        //플레이어 x축
        //플레이어 y축
        //퀘스트 id
        //quest action index
        menuSet.SetActive(false);
    }

    public void GameLoad(){

        if(!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");


        player.transform.position = new Vector3(x,y,0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
