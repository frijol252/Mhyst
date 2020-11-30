using Assets.Source.Script.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Controller controller;
    public Image hp;
    public GameObject smallBullet;
    public GameObject bigBullet;

    float hpMax = 100;
    float hpCurrent;
    // Start is called before the first frame update
    void Start()
    {
        hpCurrent = 100;
        controller.PlayerAttk += Attk;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sharer.Player.sprite;
        }
        catch (Exception ex)
        {   }
        hp.fillAmount = hpCurrent / hpMax;
        if (hpCurrent <= 0)
        {
            hpCurrent = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            hpCurrent -= other.gameObject.GetComponent<PlayerBullet>().dmg;
            Destroy(other.gameObject);
        }        
    }

    void Attk(Tuple<int, float> tuple)
    {
        GameObject bullet = null;
        if (tuple.Item2 != 0)
        {
            switch (tuple.Item1)
            {
                case 0:
                    bullet = Instantiate(smallBullet, transform.position, Quaternion.identity);
                    bullet.GetComponent<PlayerBullet>().dmg = 10f * tuple.Item2;
                    break;
                case 1:
                    bullet = Instantiate(bigBullet, transform.position, Quaternion.identity);
                    bullet.GetComponent<PlayerBullet>().dmg = 50f * tuple.Item2;
                    break;
                case 2:
                    bullet = Instantiate(smallBullet, transform.position, Quaternion.identity);
                    bullet.GetComponent<PlayerBullet>().dmg = 20f * tuple.Item2;
                    break;
            }
            bullet.GetComponent<PlayerBullet>().target = GameObject.FindWithTag("Enemy");
            bullet.tag = "PlayerBullet";
        }
    }
}
