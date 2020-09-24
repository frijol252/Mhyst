using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialC : MonoBehaviour
{
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = PersInfo.Info.Nick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clicky()
    {
        SceneManager.LoadScene(3);
    }
}
