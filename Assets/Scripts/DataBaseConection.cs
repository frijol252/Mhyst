
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;

public class DataBaseConection : MonoBehaviour
{
    void Start()
    {
        LLamarBase();
    }
    void LLamarBase()
    {
        MySqlConnection conn = new MySqlConnection();
        string cadenaConn = "Server=bojvq5dmatxn6x6sqhq7-mysql.services.clever-cloud.com;DataBase=bojvq5dmatxn6x6sqhq7;Uid=ubdyhzvbbvfhkb83;Pwd=PUXrlBXnY5HYAgaY938E;";
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
    }
}