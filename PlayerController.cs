using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public TimerController timerController;
    Rigidbody2D rigid2D;
    GameObject Timer;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.Timer = GameObject.Find("GameObject");
        timerController = Timer.GetComponent<TimerController>();
    }

    void Update()
    {
        if(timerController.jumpflag == true){
            this.rigid2D.AddForce(transform.up * 100f);
            timerController.jumpflag = false;
        }
    }
}
