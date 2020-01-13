using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{
    public Text health1, health2;
    GameObject player1, player2;
    int h1, h2;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("LeftFighter");
        player2 = GameObject.FindGameObjectWithTag("RightFighter");
    }

    // Update is called once per frame
    void Update()
    {
        h1 = player1.GetComponent<Player1Control>().Health;
        h2 = player2.GetComponent<Player2Control>().Health;

        health1.text = ("HEALTH: " + h1);
        health2.text = ("HEALTH: " + h2);
    }
}
