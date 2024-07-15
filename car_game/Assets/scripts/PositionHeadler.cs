using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionHeadler : MonoBehaviour
{

    public int scorecHhecpoint = 0;

    public int scoreCrug = 0;

    public GameObject can;

    public List<calapController> carLapCounters = new List<calapController>();

    // Start is called before the first frame update
    void Start()
    {
        calapController[] carLapCountersArray = FindObjectsOfType<calapController>();

        carLapCounters = carLapCountersArray.ToList<calapController>();

        foreach (calapController lapController in carLapCounters)
        {
            lapController.OnPassCheclPoint += OnPassCheckPoint;
        }
    }

    void OnPassCheckPoint(calapController carLapCounters)
    {

        Debug.Log($" tttttttt{carLapCounters.gameObject.name}");
    }

}
