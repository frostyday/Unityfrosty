using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;//대화 데이터 저장 목적
    Dictionary<int, Sprite> portraiData;

    public Sprite[] portraiArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraiData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData(){
        talkData.Add(1000, new string[] {"안녕?:0","플레이어 이곳은 처음이지?:1"});//문장이므로 배열 써야함 구분자 :숫자 사용
        talkData.Add(3000, new string[] {"평범한 상자이다."});
        talkData.Add(2000, new string[] {"여어:0","반가워:1"});


       portraiData.Add(1000+0, portraiArr[0]);//Getportrait함수랑 형식 맞추기 아이디+해당 인덱스
       portraiData.Add(1000+1,portraiArr[1]);
       portraiData.Add(1000+2, portraiArr[2]);
       portraiData.Add(1000+3, portraiArr[3]);
       portraiData.Add(2000+0, portraiArr[4]);
       portraiData.Add(2000+1, portraiArr[5]);
       portraiData.Add(2000+2, portraiArr[6]);
       portraiData.Add(2000+3, portraiArr[7]);

       //퀘스트 대화
       talkData.Add(10 + 1000, new string[] {"어서와:0","이 마을에는 전설이 있는데:1", "저 옆에 사람이 알려줄꺼야!:2"});

       talkData.Add(11 + 2000, new string[] {"안녕:0","전설에 대해 알고싶다고?:1", "그럼 내 집 근처에 떨어진 동전 좀 주워와줬으면해:2"});

       talkData.Add(20 + 1000, new string[] {"루도의 동전?:1", "돈을 흘리다니 나중에 루도에게 한마디 해야겠어:3"});
       talkData.Add(20 + 2000, new string[] {"찾으면 꼭 좀 가져다 줘 ㅠ:3"});
       talkData.Add(20 + 5000, new string[] {"집 근처에 있던 동전을 찾았다."});
       talkData.Add(21 + 2000, new string[] {"찾아줘서 고마워!:2"});
       

    }

    public string GetTalk(int id, int talkIndex){

        if(!talkData.ContainsKey(id)){
            if(!talkData.ContainsKey(id - id % 10))
                return GetTalk(id- id% 100, talkIndex); //반환 값이 있는 재귀함수는 return 필요
           else
                return GetTalk(id - id % 10, talkIndex);
        }

        if(talkIndex == talkData[id].Length){
            return null;
        }
        else
        return talkData[id][talkIndex];
    }
    

    public Sprite Getportrait(int id, int porraitIndex){
        return portraiData[id+ porraitIndex];
    }
}

