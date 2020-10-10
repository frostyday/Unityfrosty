using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string questName;
    public int[] npcId; // 퀘스트 주는 npc 저장

    public QuestData(string name, int[] npc){ // 생성자
        questName = name;
        npcId = npc;
    }
}
