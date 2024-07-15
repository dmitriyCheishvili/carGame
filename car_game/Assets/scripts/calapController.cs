using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class calapController : MonoBehaviour
{

    public TextMeshProUGUI textToEdit;
    

   public GameObject gameOver;

    public int maxCrug;

    int passedCheckPountNumber = 0;
    float timeLastPassedCheckPount = 0;
    public int scoreCrug = 0;

    public int numOfPassedCheckPount;

    public event Action<calapController> OnPassCheclPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPount"))
        {
            finish fin = collision.GetComponent<finish>();

            if (passedCheckPountNumber + 1 == fin.checkPointNubver)
            {
                passedCheckPountNumber = fin.checkPointNubver;

                numOfPassedCheckPount++;

                timeLastPassedCheckPount = Time.time;

                OnPassCheclPoint?.Invoke(this);
            }
        }  
    }

    void Update()
    {
        if (numOfPassedCheckPount == 6)
        {
            passedCheckPountNumber = 0;
            numOfPassedCheckPount = 0;

            scoreCrug++;

            textToEdit.text = scoreCrug.ToString();

            Fin();
        }
    }

    void Fin()
    {
        if (scoreCrug == maxCrug)
        {
            gameOver.SetActive(true);
        }
    }
  
    
}

