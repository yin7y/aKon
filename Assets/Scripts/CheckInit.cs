using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInit : MonoBehaviour
{
    public static string debugSceneName;
    void Start()
    {
        if(!GameObject.Find("Player")){
            SceneManager.LoadScene("Init");
            debugSceneName = SceneManager.GetActiveScene().name;
        }
    }
}
