using Assets.Source.Script.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public AudioSource a1;
    public AudioSource a2;

    public TextMeshProUGUI text;
    public TextMeshProUGUI textShow;
    float dmgMult;

    public delegate void playerAttk(Tuple<int, float> multiplier);
    public playerAttk PlayerAttk;
    public delegate void enemyAttk(float multiplier);
    public enemyAttk EnemyAttk;

    bool playerTurn = true;
    string res;

    int select;
    string[] words;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTurn)
        {
            EnemyAttk(UnityEngine.Random.Range(50f, 100f) / 100f);
            playerTurn = true;
        }
    }

    public void InputValidate()
    {
        /*if (playerTurn)
        {
            PlayerAttk(Calcular());
            playerTurn = false;
        }*/

        if (playerTurn)
        {
            bool x = true;
            for (int i = 0; i < (text.text.Length - 1); i++)
            {
                char aux = text.text[i];
                if (!Char.Equals(text.text[i], res[i]))
                {
                    x = false;
                }
            }
            PlayerAttk(new Tuple<int, float>(select, (x) ? 1f : 0f));
            playerTurn = false;
        }
    }

    Tuple<int, float> Calcular()
    {
        string[] a = text.text.Split(' ');
        string[] b;
        float cont = 0;
        List<float> l = new List<float>();
        foreach (string item in FightParameters.Lista)
        {
            b = item.Split(' ');
            for (int i = 0; i < b.Length; i++)
            {
                try
                {
                    int x = string.Compare(a[i], b[i]);
                    if (string.Compare(a[i], b[i]) >= 0)
                    {
                        cont++;
                    }
                }
                catch { }
            }
            l.Add(cont / ((float)b.Length));
            cont = 0;
        }
        return new Tuple<int, float>(l.IndexOf(l.Max()), l.Max());
    }

    public void Sfm()
    {
        select = 0;
        words = FightParameters.Lista[0].Split(' ');
        CadGen();
        a1.Play();
    }

    public void Bfb()
    {
        select = 1;
        words = FightParameters.Lista[1].Split(' ');
        CadGen();
        a2.Play();
    }

    void CadGen()
    {
        string cad = "";
        int index = UnityEngine.Random.Range(0, words.Length);
        res = words[index];
        words[index] = "...";
        words.ToList<string>().ForEach(x => cad += (x + " "));
        textShow.text = cad.Trim();
    }
}
