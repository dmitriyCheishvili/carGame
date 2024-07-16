using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDownUIHendle : MonoBehaviour
{

    public Text countDownText;


     void Start()
    {
        StartCoroutine(CountDownCo());
    }

    private void Awake()
    {
        countDownText.text = "";
    }

    IEnumerator CountDownCo()
    {
        yield return new WaitForSeconds(0.3f);

        int counter = 3;

        while (true)
        {
            if (counter != 0)
            {
                countDownText.text = counter.ToString();
            }
            else
            {
                countDownText.text = "GO";

                GameManager.instance.OnRaceStart();

                break;
            }

            counter--;
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
