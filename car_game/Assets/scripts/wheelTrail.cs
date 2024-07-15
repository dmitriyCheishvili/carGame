using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelTrail : MonoBehaviour
{

    car_move carmove;
    TrailRenderer trailRenderer;


    private void Awake()
    {
        carmove = GetComponentInParent<car_move>();

        trailRenderer = GetComponent<TrailRenderer>();

        trailRenderer.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (carmove.IsTireScreeching(out float lateralVelosity, out bool isBraking))
        {
            trailRenderer.emitting = true;
        }else trailRenderer.emitting = false;
    }
}
