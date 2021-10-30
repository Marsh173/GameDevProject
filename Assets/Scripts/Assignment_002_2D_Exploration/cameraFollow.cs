using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smooth;

    private void LateUpdate()
    {
        follow();
    }

    void follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothFollow = Vector3.Lerp(transform.position, targetPosition, smooth * Time.deltaTime);
        transform.position = targetPosition;
    }



}
