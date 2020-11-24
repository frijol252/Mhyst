using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvEmail : MonoBehaviour
{
    public InputField Semail;
    public InputField Squeja;
    public Text lblMsg;
    public string Stringqueja;
    public void SendMail(){
        try{
            Stringqueja=Squeja.text;
            if(Semail.text.Length>0){
                if(Stringqueja.Length>0){
                    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                    email.To.Add(Semail.text);
                    email.Subject="Solicitud de Soporte Tecnico";
                    email.SubjectEncoding = System.Text.Encoding.UTF8;
                    email.Body ="Solicitud de Soporte Tecnico."+
                                    "\nDecripcion de queja: "+Stringqueja+"."+
                                "\nSu queja sera revisada por los desarrolladores."+
                                 "\nPuede responder a este correo.";
                    email.BodyEncoding = System.Text.Encoding.UTF8;
                    email.From = new System.Net.Mail.MailAddress("MockGamesSuport@gmail.com");
                    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                    cliente.Credentials = new System.Net.NetworkCredential("MockGamesSuport@gmail.com","MockGames");
                    cliente.Port = 587;
                    cliente.EnableSsl = true;
                    cliente.Host="smtp.gmail.com";
                    cliente.Send(email);
                    lblMsg.text="Se envio un correo para revisar su Queja.";
                }else{
                    lblMsg.text="Debe ingresar una descripción.";
                }
            }else{
                lblMsg.text="Debe ingresar una direccion de correo electronico.";
            }
        }catch(UnityException ex){
            lblMsg.text="Error: "+ex.Message;
        }
    }
}
