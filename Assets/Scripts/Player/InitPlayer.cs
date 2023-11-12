using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitPlayer : MonoBehaviour
{
    public string startScene;
    void Start()
    {
        if(CheckInit.debugSceneName == null){
            SceneManager.LoadScene(startScene);
        }
        else{
            SceneManager.LoadScene(CheckInit.debugSceneName);
            CheckInit.debugSceneName = null;
        }
    }
}
