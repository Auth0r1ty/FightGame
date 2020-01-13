using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayerScript : MonoBehaviour
{
    public GameObject[] leftFighters = new GameObject[3];
    public GameObject[] rightFighters = new GameObject[3];

    int currentActive = 0;
    int currentActive2 = 0;

    private void Awake()
    {
        leftFighters = GameObject.FindGameObjectsWithTag("LeftFighter");
        rightFighters = GameObject.FindGameObjectsWithTag("RightFighter");

        for (int i = 1; i < 3; i++)
        {
            leftFighters[i].SetActive(false);
            rightFighters[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            leftFighters[currentActive].SetActive(false);
            currentActive = (currentActive + 1) % 3;
            leftFighters[currentActive].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            rightFighters[currentActive2].SetActive(false);
            currentActive2 = (currentActive2 + 1) % 3;
            rightFighters[currentActive2].SetActive(true);
        }
    }
}
