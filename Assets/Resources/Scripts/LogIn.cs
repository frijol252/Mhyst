using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Principal;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{
    public InputField email;
    public InputField pass;

    string path = "MhystI.meta";
    private static string token;
    public static string Token
    {
        get
        {
            return token;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (token != null)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void LogIn_M()
    {
        Verif();
    }

    public void SignUp_M()
    {
        Write();
        LogIn_M();
    }

    private bool Verif()
    {
        string[] aux;
        foreach (string item in File.ReadAllLines(path))
        {
            aux = item.Split('|');
            if (aux[1] == email.text && aux[2] == pass.text)
            {
                token = aux[0];
                return true;
            }
        }
        return false;
    }

    private void Write()
    {
        int id = File.ReadAllLines(path).Length;
        StreamWriter wr = File.AppendText(path);
        wr.WriteLine(id + "|" + email.text + "|" + pass.text);
        wr.Close();
    }
}
