using Assets.Source.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightChatBehavior : MonoBehaviour
{
    Animator animator;

    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("FightChat", FightParameters.PlayerTurn);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FightParameters.PlayerTurn = (FightParameters.PlayerTurn) ? false : true;
        }
    }
}
