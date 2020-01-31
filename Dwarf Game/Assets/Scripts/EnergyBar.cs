using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Image energyFill;
    public PointTracker ptTracker;
    public float counter;
    public int elapsedTime;
    public float maxTime = 100f;
    //private bool gameOver;

    void Start()
    {
        elapsedTime = 0;
        counter = 0f;
        //gameOver = false;
        if (ptTracker == null)
            ptTracker = FindObjectOfType<PointTracker>().GetComponent<PointTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 1f )
        {
            counter = 0f;
            elapsedTime++;
            energyFill.fillAmount = (maxTime-elapsedTime)/maxTime;
            ptTracker.AddScore(1);
        }
        
    }
}
