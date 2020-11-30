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
using MySql.Data.MySqlClient;
public class Controller : MonoBehaviour
{
    public AudioSource a1;
    public AudioSource a2;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textShow;
    float dmgMult;
    private string cadenaConn = "Server=bojvq5dmatxn6x6sqhq7-mysql.services.clever-cloud.com;DataBase=bojvq5dmatxn6x6sqhq7;Uid=ubdyhzvbbvfhkb83;Pwd=PUXrlBXnY5HYAgaY938E;";
    
    public delegate void playerAttk(Tuple<int, float> multiplier);
    public playerAttk PlayerAttk;
    public delegate void enemyAttk(float multiplier);
    public enemyAttk EnemyAttk;

    bool playerTurn = true;
    string res;
    int select;
    string[] arr=new string[3];
    string[] words;
    void Start()
    {
        
    }

    
    void Update()
    {
        
        if (!playerTurn)
        {
            EnemyAttk(UnityEngine.Random.Range(50f, 100f) / 100f);
            playerTurn = true;
            CadGen();
        }
        
    }

    public void InputValidate(int number)
    {
        

        if (playerTurn)
        {
            bool x = true;
                try
                {
                    if (arr[number]==1.ToString())
                    {
                        PlayerAttk(new Tuple<int, float>(select, (x) ? 1f : 0f));
                        playerTurn = false;
                    }
                    else{
                        playerTurn = false;
                    }
                }
                catch (Exception)
                {
                    x = false;
                }    
            
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
        CadBaseGen();
        a1.Play();
    }

    public void Bfb()
    {
        select = 1;
        CadBaseGen();
        a2.Play();
    }

    void CadGen()
    {
        words = FightParameters.Lista[select].Split(' ');
        string cad = "";
        int index;
        do
        {
            index = UnityEngine.Random.Range(0, words.Length);
            res = words[index];
        } while (res.Length <= 4);
        words[index] = "...";
        words.ToList<string>().ForEach(x => cad += (x + " "));
        textShow.text = cad.Trim();
    }
    string id;
    string phrase;
    string complete;
    string correct;
    
    public TMP_Text b1text;
    public TMP_Text b2text;
    public TMP_Text b3text;

    void CadBaseGen()
    {
        MySqlConnection conn = new MySqlConnection(cadenaConn);
            conn.Open();
            
        try
        {
            int rdm=UnityEngine.Random.Range(0, 4);
            MySqlCommand cmd=conn.CreateCommand();
            cmd.CommandText= "select idphrases,incompletePhrase from Phrases where numberPhrase="+(select+1)+" limit 1 offset "+rdm;
            MySqlDataReader res=cmd.ExecuteReader();
            while (res.Read())
            {
                id=res[0].ToString();
                phrase=res[1].ToString();
            }
            textShow.text=phrase;
                
            for(int i=0;i<3;i++){
                Debug.Log(""+i);
                conn.Close();
                conn.Open();
                switch (i)
                {
                    case 0:

                        MySqlCommand cmd1=conn.CreateCommand();
                        cmd1.CommandText= "select part, correct from CompletePhrases where idphrases="+id+" limit 1 offset "+i;
                        MySqlDataReader res1=cmd1.ExecuteReader();
                        while (res1.Read())
                        {
                            complete=res1[0].ToString();
                            correct=res1[1].ToString();
                        }
                        arr[i]=correct;
                        b1text=btn1.GetComponentInChildren<TMP_Text>(true);
                        b1text.text = complete;
                        
                    break;
                    case 1:
                        MySqlCommand cmd2=conn.CreateCommand();
                        cmd2.CommandText= "select part, correct from CompletePhrases where idphrases="+id+" limit 1 offset "+i;
                        MySqlDataReader res2=cmd2.ExecuteReader();
                        while (res2.Read())
                        {
                            complete=res2[0].ToString();
                            correct=res2[1].ToString();
                        }
                        arr[i]=correct;
                        b2text=btn2.GetComponentInChildren<TMP_Text>(true);
                        b2text.text = complete;
                    break;
                    case 2:
                        MySqlCommand cmd3=conn.CreateCommand();
                        cmd3.CommandText= "select part, correct from CompletePhrases where idphrases="+id+" limit 1 offset "+i;
                        MySqlDataReader res3=cmd3.ExecuteReader();
                        while (res3.Read())
                        {
                            complete=res3[0].ToString();
                            correct=res3[1].ToString();
                        }
                        arr[i]=correct;
                        b3text=btn3.GetComponentInChildren<TMP_Text>(true);
                        b3text.text = complete;
                    break;
                }
            }
            
        }
        catch (MySqlException ex)
        {
            Debug.Log("Error"+ex);
        }
        finally{
            conn.Close();
        }
    }

    void verficar(int number){

    }
}
