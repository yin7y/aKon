using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject hp_bar;
    int hp;
    public int max_hp;
    void Start() {
        hp = max_hp;
    }
    void Update(){
        if(hp <= 0){
            hp = 0;
            Destroy(this.gameObject);
        }
        hp_bar.transform.localScale = new Vector3(((float)hp / (float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "FireBall"){
            hp -= 1;
            print(other.gameObject.name);
            Destroy(other.gameObject);
        }        
    }
}
