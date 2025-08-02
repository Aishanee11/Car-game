using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float Timertime = 5f;

    // Update is called once per frame
    void Update()
    {
        

        if(Timertime > 0.01f)
        {
            Debug.Log(Timertime);
            Timertime = Timertime - Time.deltaTime;
           

        }
         
    }
}
