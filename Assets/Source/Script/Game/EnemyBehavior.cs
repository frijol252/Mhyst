﻿using Assets.Source.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public Image hp;
    public GameObject fb;
    public Controller controller;

    float hpMax = 100;
    float hpCurrent;
    // Start is called before the first frame update
    void Start()
    {
        hpCurrent = 100;
        controller.EnemyAttk += Attk;
    }

    // Update is called once per frame
    void Update()
    {
        hp.fillAmount = hpCurrent / hpMax;
        if (hpCurrent <= 0)
        {
            Debug.Log("asd");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            hpCurrent -= other.gameObject.GetComponent<PlayerBullet>().dmg;
            Destroy(other.gameObject);
        }
    }

    void Attk(float dmg)
    {
        GameObject bullet = Instantiate(fb, transform.position, Quaternion.identity);
        bullet.GetComponent<PlayerBullet>().dmg = 10f * dmg;
        bullet.GetComponent<PlayerBullet>().target = GameObject.FindWithTag("Player");
        bullet.tag = "EnemyBullet";
    }
}
