using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ControlDirector : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject Musica;
    bool start=false;
    bool isFadeIn=false;
    float alpha=0;
    float fadeTime=1f;

    void Update(){
        if(director.time>12&&director.time>13){
            FadeIn();
        }
        if(director.time>14&&director.time>15){
            FadeOut();
        }
    }
    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector){
            Musica.GetComponent<AudioSource>().Play();
        }
            
    }

    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }
    void OnGUI () {
        
        // Si no empieza la transición salimos del evento directamente
        if (!start)
            return;

        // Si ha empezamos creamos un color con una opacidad inicial a 0
        GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        // Creamos una textura temporal para rellenar la pantalla
        Texture2D tex;
        tex = new Texture2D (1, 1);
        tex.SetPixel (0, 0, Color.black);
        tex.Apply ();

        // Dibujamos la textura sobre toda la pantalla
        GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), tex);

        // Controlamos la transparencia
        if (isFadeIn) {
            // Si es la de aparecer le sumamos opacidad
            alpha = Mathf.Lerp (alpha, 1.1f, fadeTime * Time.deltaTime);
            
        } else {
            // Si es la de desaparecer le restamos opacidad
            alpha = Mathf.Lerp (alpha, -0.1f, fadeTime * Time.deltaTime);
            
            // Si la opacidad llega a 0 desactivamos la transición
            if (alpha < 0) start = false;
        }

    }

    // Método para activar la transición de entrada
    void FadeIn () {
        start = true;
        isFadeIn = true;
    }

    // Método para activar la transición de salida
    void FadeOut () {
        isFadeIn = false;
    }
}
