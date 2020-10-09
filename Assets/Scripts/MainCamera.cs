using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
     public float smoothTime = 3f;

    Transform target;
    float tLX, tLY, bRX, bRY;

    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        float posX = Mathf.Round( 
            Mathf.SmoothDamp(transform.position.x, 
                target.position.x, ref velocity.x, smoothTime
            ) * 100) / 100;

        float posY = Mathf.Round( 
            Mathf.SmoothDamp(transform.position.y, 
                target.position.y, ref velocity.y, smoothTime
            ) * 100) / 100;

        transform.position = new Vector3(
            Mathf.Clamp(posX,tLX,bRX),
            Mathf.Clamp(posY,bRY,tLY),
            transform.position.z
        );
    }
    public void SetBound(float x,float y,float mx,float my){
        tLX=x;
        tLY=y;
        bRX=mx;
        bRY=my;
        
        FastMove();
    }

    public void FastMove(){

        transform.position = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );
    }
}
