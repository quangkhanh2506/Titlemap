using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 3;
    public Vector3 offset;

    public Transform transBotLeft;
    public Transform transTopRight;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smoothSpeed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, transBotLeft.position.x, transTopRight.position.x),
                                         Mathf.Clamp(transform.position.y, transBotLeft.position.y, transTopRight.position.y),
                                         transform.position.z);
    }
}
