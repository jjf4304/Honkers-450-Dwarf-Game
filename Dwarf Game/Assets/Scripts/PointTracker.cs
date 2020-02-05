using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTracker : MonoBehaviour
{
    private EnergyBar energyScript;

    public GameObject pointDisplay;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        energyScript = GetComponent<EnergyBar>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointDisplay.GetComponent<Text>().text = score.ToString();   
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Values.Score = score;
    }
}
