using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    
    //la velocidad del personaje
    public float x=0,y=0,mx=0,my=0;
    public float speed = 4f;
    Animator animator;
    Rigidbody2D rb2d;
    Vector2 mov;
    void Awake() {
        
    }

    void Start()
    {
        animator=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<MainCamera>().SetBound(x,y,mx,my);
    }

    // Update is called once per frame
    void Update()
    {
        mov=new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        if(mov != Vector2.zero){
            animator.SetFloat("movX", mov.x);
            animator.SetFloat("movY", mov.y);
            animator.SetBool("walking", true);
        }
        else{
            animator.SetBool("walking", false);
        }
    }
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}
