using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] string waveName;
    public int pointNumber;
    
    void Start(){
        this.transform.tag = "Portal";
    }
    public void ChangeScene(){
        SceneManager.LoadScene(waveName);
        CheckInit.startPointNumber = pointNumber;
    }
}
