using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : StateMachineBehaviour
{
    public void OnAnimationEnd()
    {
        // 在动画结束时执行的代码
        Debug.Log("Animation ended!");
        
    }
}
