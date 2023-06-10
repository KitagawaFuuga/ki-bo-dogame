using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    
    GameObject Score;

    void Start()
    {

        Score = GameObject.Find("Score");
        Score.GetComponent<TextMeshProUGUI>().text = "Your Score = " + (TimerController.point).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("main");
        }
    }
}
