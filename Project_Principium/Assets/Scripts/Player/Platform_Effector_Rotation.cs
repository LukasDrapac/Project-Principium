using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Effector_Rotation : MonoBehaviour
{
    float timeB = 0;
    float waitingTime = 0.15f;
    bool platformEffectorReverse;
    PlatformEffector2D platformEffectorObject;
    void Start()
    {
        platformEffectorObject = gameObject.GetComponent<PlatformEffector2D>();
        platformEffectorReverse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.S))
        {
            platformEffectorObject.rotationalOffset = 180;
            platformEffectorReverse = true;
            timeB = 0;
        }

        if (platformEffectorReverse && timeB >= waitingTime)
        {
            platformEffectorReverse = false;
            platformEffectorObject.rotationalOffset = 0;
        }
        else
        {
            timeB = timeB + Time.deltaTime;
        }
    }
}
