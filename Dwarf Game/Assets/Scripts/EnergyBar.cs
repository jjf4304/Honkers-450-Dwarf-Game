using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Image energyFill;
    public float counter;
    public int amountToDeduct;
    public float maxTime;
    

    //private bool gameOver;

    void Start()
    {
        amountToDeduct = 0;
        counter = 0f;
        //gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 1f )
        {
            counter = 0f;
            amountToDeduct++;
            energyFill.fillAmount = (maxTime-(amountToDeduct))/maxTime;
        }

        if (amountToDeduct >= maxTime - 0.005)
        {
            SceneManager.LoadScene("EndGame");
        }

        
    }

    public void AddEnergy(int amount)
    {
        amountToDeduct -= amount;
        if (amountToDeduct < 0)
            amountToDeduct = 0;
        energyFill.fillAmount = (maxTime - (amountToDeduct)) / maxTime;
    }
}
