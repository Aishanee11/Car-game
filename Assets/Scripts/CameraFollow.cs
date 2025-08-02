using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carTransform;

    public Transform cameraTransform;

    void LateUpdate()
    {
        cameraTransform.position = new Vector3(carTransform.position.x, carTransform.position.y, -10f);

        
    }
}
