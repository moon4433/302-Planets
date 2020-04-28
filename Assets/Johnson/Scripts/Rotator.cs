using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float yaw = 0;
    public Transform target;


    void Update()
    {

        Vector3 vectorToTarget = target.position - transform.position;

        yaw = Mathf.Atan2(vectorToTarget.x, vectorToTarget.z);
        Quaternion desiredRotation = Quaternion.LookRotation(vectorToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, .1f);
    }
}
