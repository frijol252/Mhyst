using Assets.Resources.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersInfo : MonoBehaviour
{
    string path = "MhystF.meta";
    private static UserInfo info;
    public static UserInfo Info
    {
        get
        {
            return info;
        }
    }

    public InputField nick;
    public InputField nombre;
    public Dropdown sexo;
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        try
        {
            Read();
        }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        if (info != null)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void Read()
    {
        string[] aux;
        foreach (string item in File.ReadAllLines(path))
        {
            aux = item.Split('|');
            if (aux[0] == LogIn.Token)
            {
                info = new UserInfo
                {
                    Nick = aux[1],
                    Nombre = aux[2],
                    Sexo = aux[3]
                };
            }
        }
    }

    public void Confirm()
    {
        StreamWriter wr = File.AppendText(path);
        wr.WriteLine(LogIn.Token + "|" + nick.text + "|" + nombre.text + "|" + sexo.options[sexo.value].text);
        wr.Close();
        Read();
    }
}
