using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject hp_bar;
    int hp;
    public int max_hp;
    public float speed;
    Transform myTransform;
    SpriteRenderer spr;
    public Transform playerTransform;
    
    
    public enum Status{idle, walk};
    public Status status;
    public enum Face{Right, Left};
    public Face face;
    
    void Start() {
        hp = max_hp;
        status = Status.idle;
        spr = this.transform.GetComponent<SpriteRenderer>();
        
        if(this.transform.GetComponent<SpriteRenderer>().flipX){
            face = Face.Right;
        }else{
            face = Face.Left;
        }
        myTransform = this.transform;
        if(GameObject.Find("Player") != null){
            playerTransform = GameObject.Find("Player").transform;
        }
        
    }
    void Update(){
        if(hp <= 0){
            hp = 0;
            Destroy(this.gameObject);
        }
        hp_bar.transform.localScale = new Vector3(((float)hp / (float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
        
        float deltaTime = Time.deltaTime;
        switch(status){
            case Status.idle:
                print(Mathf.Abs(myTransform.position.x - playerTransform.position.x));
                if(Mathf.Abs(myTransform.position.x - playerTransform.position.x) < 4.0f){
                    status = Status.walk;
                }
                break;
            case Status.walk:
                if(playerTransform){
                    if(myTransform.position.x >= playerTransform.position.x){
                        spr.flipX = false;
                        face = Face.Left;
                    }else{
                        spr.flipX = true;
                        face = Face.Right;
                    }
                }                
                switch(face){
                    case Face.Right:
                        myTransform.position += new Vector3(speed * deltaTime, 0, 0);
                        break;
                    case Face.Left:
                        myTransform.position -= new Vector3(speed * deltaTime, 0, 0);
                        break;
                }
                if(playerTransform){
                    if(Mathf.Abs(myTransform.position.x - playerTransform.position.x) >= 4.0f){
                        status = Status.idle;
                    }
                }
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "FireBall"){
            hp -= 1;
            print(other.gameObject.name);
            Destroy(other.gameObject);
        }        
    }
}
