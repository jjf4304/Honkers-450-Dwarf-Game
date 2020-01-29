using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTracker : MonoBehaviour
{
    private float counter;

    public GameObject pointDisplay;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 0.5f)
        {
            counter = 0;
            points += 1;
            UpdatePoints();
        }
    }

    void UpdatePoints()
    {
        pointDisplay.GetComponent<Text>().text = points.ToString();
    }
}
