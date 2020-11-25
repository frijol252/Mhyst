using Assets.Resources.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class DataBaseConection : MonoBehaviour
{
    public InputField userName;
    public InputField email;
    public InputField password;
    public Dropdown sexo;
    private string cadenaConn = "Server=bojvq5dmatxn6x6sqhq7-mysql.services.clever-cloud.com;DataBase=bojvq5dmatxn6x6sqhq7;Uid=ubdyhzvbbvfhkb83;Pwd=PUXrlBXnY5HYAgaY938E;";
    void Start()
    {
        LLamarBase();
    }
    void LLamarBase()
    {
        MySqlConnection conn = new MySqlConnection();
       
        conn.ConnectionString = cadenaConn;
        try
        {
            conn.Open();
            Debug.Log("Conexion Establecida");
        }
        catch(MySqlException ex)
        {
            Debug.Log("Conexion No Establecida"+ex);
        }
        finally{
            conn.Close();
        }
    }

    public void register()
    {
        MySqlConnection conn = new MySqlConnection(cadenaConn);
        try
        {
            string Consulta=@"INSERT INTO Users(userName,password,email,genero)
                                VALUES('"+userName.text+"',MD5('"+password.text+"'),'"+email.text+"','"+sexo.options[sexo.value].text+"');";
            
            MySqlCommand cmd=new MySqlCommand(Consulta,conn);
            conn.Open();
            cmd.ExecuteReader();
            SceneManager.LoadScene(0);
        }
        catch(MySqlException ex)
        {
            Debug.Log("Error"+ex);
        }
        finally{
            conn.Close();
        }
    }
    public void Login()
    {
        MySqlConnection conn = new MySqlConnection(cadenaConn);
            conn.Open();
            
        try
        {
            MySqlCommand cmd=conn.CreateCommand();
            cmd.CommandText= "SELECT * FROM Users WHERE email='"+email.text+"' and password=MD5('"+password.text+"')";
            MySqlDataReader res=cmd.ExecuteReader();
            if (res.HasRows)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
               userName.text="El usuario No Existe";
            }
        }
        catch (MySqlException ex)
        {
            Debug.Log("Error"+ex);
        }
        finally{

        }
    }
    public void GoToRegister(){
        SceneManager.LoadScene(1);
    }
}