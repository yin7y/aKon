using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator playerAnim;
    public GameObject fireBallPrf;
    public Image hp_bar;
    
    Vector2 moveVector;
    public int hp;
    public int max_hp;
    float currentHpScale;
    [SerializeField] float moveSpeed;
    
    bool isAtking;
    
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        playerAnim = this.gameObject.GetComponent<Animator>();
        hp = max_hp;
    }

    void Update()
    {
        if(moveVector != Vector2.zero){
            this.transform.position += new Vector3(moveVector.x,moveVector.y,0) * Time.deltaTime * moveSpeed;
            playerAnim.SetBool("isMove", true);
            Flip();
        }
        else{
            playerAnim.SetBool("isMove", false);
        }
        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
            playerAnim.SetBool("isAttack", false);
        }
        
        currentHpScale = (float)hp / (float)max_hp;
        currentHpScale = currentHpScale <= 0 ? 0 : (float)hp / (float)max_hp;
        hp_bar.transform.localScale = new Vector3(currentHpScale, this.transform.localScale.y, this.transform.localScale.z);
    }
    public void Move(InputAction.CallbackContext _ctx){
        moveVector = _ctx.ReadValue<Vector2>();
    }
    public void Attack(InputAction.CallbackContext _ctx){
        if(_ctx.started){
            playerAnim.SetBool("isAttack", true);
            isAtking = true;
            Instantiate(fireBallPrf, this.transform.position, Quaternion.identity);
            print("ATTACK!!!");
        }
    }
    public void Jump(InputAction.CallbackContext _ctx){
        if(_ctx.started){
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }
    
    
    void OnCollisionEnter2D(Collision2D _coll) {
        if(_coll.gameObject.tag == "Enemy"){
            print(_coll.gameObject.name);
            hp -= 1;
        }        
    }
    void OnTriggerEnter2D(Collider2D _coll) {
        if(_coll.gameObject.tag == "Portal"){
            _coll.gameObject.transform.GetComponent<Portal>().ChangeScene();
        }        
    }
    
    
    void Flip(){
        Vector3 newScale = transform.localScale;
        if(moveVector.x < 0){
            newScale.x = -1;   
        }
        else
            newScale.x = 1;
        transform.localScale = newScale;
    }
}
