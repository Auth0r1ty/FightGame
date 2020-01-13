using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFightScene : MonoBehaviour
{
    public void LoadFightOnClick()
    {
        GameObject p1 = GameObject.FindGameObjectWithTag("LeftFighter");
        p1.AddComponent<Player1Control>();
        DontDestroyOnLoad(p1);

        GameObject p2 = GameObject.FindGameObjectWithTag("RightFighter");
        p2.AddComponent<Player2Control>();
        DontDestroyOnLoad(p2);


        SceneManager.LoadScene("FightScene");
    }
}
