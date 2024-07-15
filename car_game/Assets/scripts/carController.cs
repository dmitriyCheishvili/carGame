using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    car_move carMove;
    

    private void Awake()
    {
        carMove = GetComponent<car_move>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 inpunVector = Vector2.zero;

        inpunVector.x = Input.GetAxis("Horizontal"); 
        inpunVector.y = Input.GetAxis("Vertical");
     

        carMove.SetInputVector(inpunVector);
    }
}
