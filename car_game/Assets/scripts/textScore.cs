using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textScore : MonoBehaviour
{
    calapController calap;
    public TextMeshProUGUI textToEdit;

    // Start is called before the first frame update
    void Start()
    {
        calap = GetComponent<calapController>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText();
    }

    void ScoreText()
    {
      if (calap.scoreCrug == 0)
        {
            textToEdit.text = calap.scoreCrug.ToString();
        }
       

    }

}
