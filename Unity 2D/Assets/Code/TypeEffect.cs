using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;
    public int CharPerSeconds;
    public GameObject EndCursor;
    Text msgText;
    int index;
    float interval;
    AudioSource audioSource;
    public bool isAnim;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void SetMsg(string msg)
    {
        if(isAnim){
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else{
        targetMsg = msg;
        EffectStart();
        }
    }

    void EffectStart(){
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        interval = 1.0f/CharPerSeconds;
        Debug.Log(interval);

        isAnim =true;
        Invoke("Effecting", interval);
    }

    void Effecting(){
        if(msgText.text == targetMsg){
            EffectEnd();
            return;
        }
         msgText.text += targetMsg[index];

      if(targetMsg[index] != ' ' || targetMsg[index] != '.')//공백과 마침표는 재생 제외
        audioSource.Play();
        index++;
        //소리 출력

        Invoke("Effecting", interval);
    }

    void EffectEnd(){
        isAnim = false;
        EndCursor.SetActive(true);
    }
}
