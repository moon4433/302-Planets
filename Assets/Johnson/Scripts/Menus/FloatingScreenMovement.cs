using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScreenMovement : MonoBehaviour
{

    Transform menuPos;

    public float movingNum = 0;
    public float moveMult = 0.0005f;

    bool goingUp = true;
    bool goingDown = false;
    
    void Start()
    {
        menuPos = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingNum < 0)
        {
            goingUp = true;
            goingDown = false;
        }
        else if (movingNum > 1)
        {
            goingDown = true;
            goingUp = false;
        }

        float ty = menuPos.position.y;
        float tx = menuPos.position.x;
        tx = Mathf.Cos(Time.time);

        if (goingUp)
        {
            ty += moveMult;
            menuPos.position = new Vector3(menuPos.position.x, ty, menuPos.position.z);
            movingNum += .005f;
        }
        else if (goingDown)
        {
            ty -= moveMult;
            menuPos.position = new Vector3(menuPos.position.x, ty, menuPos.position.z);
            movingNum -= .005f;
        }



    }
}
