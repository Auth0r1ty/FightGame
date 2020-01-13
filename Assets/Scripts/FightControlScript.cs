using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControlScript : MonoBehaviour
{
    GameObject player1, player2;
    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("LeftFighter");
        player2 = GameObject.FindGameObjectWithTag("RightFighter");
    }

    public void Notify(string player_id)
    {
        if(player_id.Equals("1"))
        {
            player1.GetComponent<Player1Control>().Health -= 20;
        }
        else
        {
            player2.GetComponent<Player2Control>().Health -= 20;
        }
    }
}
