using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{   
    GameObject TimerText, playerText, enenyText, youser, girl, scoreText,badbgm;
    GameObject[] harts = new GameObject[3];

    float timer = 3.0f;
    int Randoms = 0,checnpoint = 0, hartcheck = 2;
    public static int point;
    string[] enemyText = {"UpArrow", "DownArrow", "LeftArrow", "RightArrow", "A", "B", "C", "D", "E", "F", "G"};
    bool checkfirst = false;
    public bool jumpflag = false;

    void Start(){
        TimerText  = GameObject.Find("Timetext");
        playerText = GameObject.Find("youranswer");
        enenyText  = GameObject.Find("print");
        youser     = GameObject.Find("seifuku1_gakuran");
        girl       = GameObject.Find("seifuku2_sailor");
        scoreText  = GameObject.Find("Score");
        badbgm     = GameObject.Find("missBGM");
        harts[0]   = GameObject.Find("hart1");
        harts[1]   = GameObject.Find("hart2");
        harts[2]   = GameObject.Find("hart3");
        point = 0;
        checnpoint = 0;
    }

    void Update(){
        timer -= Time.deltaTime;
        TimerText.GetComponent<TextMeshProUGUI>().text = timer.ToString("N2"); 
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + point.ToString();
        if(timer <= 0){
            Randoms = UnityEngine.Random.Range(0, enemyText.Length);
            enenyText.GetComponent<TextMeshProUGUI>().text = enemyText[Randoms];
            if(checkfirst){
                Destroy(harts[hartcheck]);
                badbgm.GetComponent<AudioSource>().Play(); 
                hartcheck--;
                if(hartcheck <= 0){
                    SceneManager.LoadScene("GameOver");
                }
                timer = 10.0f;
            }else{
                timer = 3.0f;
            }
            checkfirst = true;
        }
        DownKeyCheck(enemyText[Randoms]);
    }

    void DownKeyCheck(string moi){
        if(Input.anyKeyDown){
            foreach(KeyCode code in Enum.GetValues(typeof(KeyCode))){
                if(Input.GetKeyDown(code)){
                    playerText.GetComponent<TextMeshProUGUI>().text = code.ToString();
                    if(moi == code.ToString()){
                        youser.GetComponent<AudioSource>().Play();
                        Randoms = UnityEngine.Random.Range(0, enemyText.Length);
                        enenyText.GetComponent<TextMeshProUGUI>().text = enemyText[Randoms];
                        jumpflag = true;
                        if(checnpoint <= 15){
                            point++;
                            timer = 3.0f;
                        }else if(checnpoint > 15 && checnpoint <= 25){
                            point = point + 2;
                            timer = 2.0f;
                        }else {
                            point = point + 3;
                            timer = 1.0f; 
                        }
                    }else{
                        girl.GetComponent<AudioSource>().Play(); 
                        point--;
                    }
                    break;
                }
            }
        }
    }
}
