using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTracker : MonoBehaviour
{
    private EnergyBar energyScript;

    public GameObject pointDisplay;

    // Start is called before the first frame update
    void Start()
    {
        energyScript = GetComponent<EnergyBar>();
    }

    // Update is called once per frame
    void Update()
    {
        pointDisplay.GetComponent<Text>().text = energyScript.elapsedTime.ToString();
    }
}
