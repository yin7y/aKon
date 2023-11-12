using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] string waveName;
    void Start()
    {
        this.transform.tag = "Portal";
    }

    void Update()
    {
        
    }
    
    public void ChangeScene(){
        SceneManager.LoadScene(waveName);
    }
}
