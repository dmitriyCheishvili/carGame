using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class wheels : MonoBehaviour
{
    Vector3 localAngle;
    float steerAngle, maxsteerAngle = 30f;

    private void Update()
    {
        steerAngle = -Input.GetAxis("Horizontal") * maxsteerAngle;
    }

    private void LateUpdate()
    {
        localAngle = transform.localEulerAngles;
        localAngle.z = steerAngle;
        transform.localEulerAngles = localAngle;
    }
}
