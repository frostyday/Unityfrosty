
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{

    string title = "전설의";
    int level = 5;
    float stength = 15.5f;
    string playerName = "나검사";
    int exp = 1500;
    int health = 30;
    int mana = 25;

    bool isFullLevel = false;
    void Start()
    {

        //1.변수


        //2.그룹형 변수
        string[] monsters = { "슬라임", "뱀", "악마" };
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 2;
        monsterLevel[2] = 20;

        List<string> items = new List<string>();
        items.Add("생명물약30");
        items.Add("마나물약30");
        //3.연산자


        exp = 1500 + 320;
        exp = exp - 10;
        level = exp / 300;
        stength = level * 3.1f;


        int nextExp = 300 - (exp % 300);

        string title = "전설의";

        int fullLevel = 99;
        isFullLevel = level == fullLevel;

        bool isEndTutorial = level > 10;


        bool isBadCondition = health <= 50 || mana < 20;

        string condition = isBadCondition ? "나쁨" : "좋음";
        //5. 조건문
        if (condition == "나쁨")
        {
            Debug.Log("플레이어 상태가 나쁘니 아이템을 사용하세요!");
        }
        else
        {
            Debug.Log("플레이어 상태가 좋습니다");
        }

        if (isBadCondition && items[0] == "생명물약30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("생명포션 사용!");
        }
        else if (isBadCondition && items[0] == "마나물약30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("마나포션 사용!");
        }

        switch (monsters[1])
        {
            case "슬라임":

                break;
            case "악마":

                break;
            case "골렘":

                break;
            default:

                break;
        }

        //6.반복문
        while (health > 0)
        {
            health--;
            if (health > 0) { }

            else
            {
                Debug.Log("사망");
            }
            if (health == 10)
            {

                break;
            }

        }


        for (int count = 0; count < 10; count++)
        {
            health++;

            for (int index = 0; index < monsters.Length; index++)
            {

            }

            foreach (string monster in monsters)
            {
            } // 직접 가져와서 작동


        }

        health = Heal(health);
        //7.함수(메소드)


        for (int index = 0; index < monsters.Length; index++) {
            Debug.Log("용사는" + monsters[index] + "에게 " + Battle(monsterLevel[index]));
        }

        //8.클래스
        player player = new player();
        player.name = "검사";
        Debug.Log(player.name);

    }



    int Heal(int currenthealth)
        {
            currenthealth += 10;
            Debug.Log("힐을 받았습니다. " + currenthealth);
            return currenthealth;

        }

        string Battle(int monsterLevel) {
            string result;
            if (level >= monsterLevel)
                result = "이겼다!";
            else
                result = "졌다 ㅠㅠ";

            return result;
        }
    }

