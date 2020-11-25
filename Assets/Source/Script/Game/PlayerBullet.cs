using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject target;
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = target.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 3f * Time.deltaTime);
    }
}
