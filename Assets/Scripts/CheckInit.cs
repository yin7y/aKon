using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInit : MonoBehaviour
{
    public static string debugSceneName;
    public static int startPointNumber;
    public GameObject playerObject;
    void Start()
    {
        playerObject = GameObject.Find("Player");
        if(!playerObject){
            SceneManager.LoadScene("Init");
            debugSceneName = SceneManager.GetActiveScene().name;
        }
        if(startPointNumber != 0){
            GameObject g = GameObject.Find(startPointNumber.ToString()) as GameObject;
            if(g != null){
                playerObject.transform.position = g.transform.position;
            }
            startPointNumber = 0;
        }
    }
}
