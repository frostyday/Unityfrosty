using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    void Awake()//게임 실행시 최초 1회 실행
    {
        Debug.Log("플레이어 데이터가 준비되었습니다.");
    }
    void OnEnable()//게임 오브젝트가 활성화 되었을때
    {
        Debug.Log("플레이어 로그인"); 
    }
    void Start()//업데이트 시작직전 최초 1회 실행
    {
        Debug.Log("사냥 장비를 챙겼습니다.");
    }

    void FixedUpdate()//물리 연산 업데이트 고정 주기로 실행 CPU 많이 사용
    {
        Debug.Log("이동~");
    }
    void Update()//게임 로직 업데이트 컴퓨터에 따라 실행주기 다름
    {
         Debug.Log("몬스터 사냥!");
    }

    void LateUpdate() // 모든 업데이트 끝난 후 카메라나 로직 후처리 담당
    {
         Debug.Log("경험치 획득");
    }

    void OnDisable()//게임 오브젝트가 비활성화 되었을때
    {
         Debug.Log("로그아웃");
    }
    void OnDestroy()//게임 오브젝트가 삭제될때 무언가 남긴다고 생각하면 된다고함
    {
         Debug.Log("플레이어 데이터 해체");
    }

}
