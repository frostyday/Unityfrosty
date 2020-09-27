using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI 가져오기
public class GameManagerLogic : MonoBehaviour
{   
    public int TotalItemCount;
    public int stage; //스테이지 기록
    public Text stageCountText;
    public Text playerCountText;


    void Awake()
    {
        stageCountText.text = "/ " +  TotalItemCount;
    }
    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(stage);
        }
    }
}
