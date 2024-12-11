using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    GameObject goodPointsRow, badPointsRow;
    int totalGoodPoints, totalBadPoints;
    
    void Start()
    {
        totalBadPoints = 0;
        totalGoodPoints = 0;
        goodPointsRow = transform.GetChild(0).gameObject;
        badPointsRow = transform.GetChild(1).gameObject;
    }

    public void AddPoint(bool positive, int fraudIndex)
    {
        GameObject postIt;
        if (positive) 
        {
            postIt = goodPointsRow.transform.GetChild(fraudIndex).gameObject;
            int currentScore = int.Parse(postIt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
            postIt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (currentScore + 1).ToString();
            if (!postIt.activeSelf)
                postIt.SetActive(true);
            totalGoodPoints++;
        }
        else
        {
            postIt = badPointsRow.transform.GetChild(fraudIndex).gameObject;
            int currentScore = int.Parse(postIt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
            postIt.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (currentScore + 1).ToString();
            if (!postIt.activeSelf)
                postIt.SetActive(true);
            totalBadPoints++;
        }
    }
}
