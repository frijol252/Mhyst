using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyControl : MonoBehaviour
{
    public Button btnBuy;
    public Button btnHistoria;
    public Text msg;
    public void successBuy(){
        btnBuy.transform.localScale = new Vector3(0, 0, 0);
        msg.text="Compra exitosa";
        StartCoroutine("mrgOut");
        btnHistoria.enabled=true;
    }
    public void failBuy(){
        msg.text="Compra fallida";
        StartCoroutine("mrgOut");
    }
    IEnumerator mrgOut(){
        yield return new WaitForSeconds(2);
        msg.text="";
    }
}
