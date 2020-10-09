using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject target;
    bool start=false;
    bool isFadeIn=false;
    float alpha=0;
    public string name="Default";
    float fadeTime=1f;
    GameObject area;
    public AudioClip music;
    public GameObject Musica;
    void Awake() {
        GetComponent<SpriteRenderer>().enabled=false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled=false;
        area=GameObject.FindGameObjectWithTag("Area");
    }
    
    IEnumerator OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<Animator>().enabled=false;
        other.GetComponent<MovimientoPersonaje>().enabled=false;
        Musica.GetComponent<AudioSource>().Stop();
        Musica.GetComponent<AudioSource>().clip=music;
        FadeIn();

        yield return new WaitForSeconds(fadeTime);

        SeguirCamera seguir= GetComponent<SeguirCamera>();
        other.transform.position=target.transform.GetChild(0).transform.position;
        Camera.main.GetComponent<MainCamera>().SetBound(seguir.x,seguir.y,seguir.mapx,seguir.mapy);

        FadeOut();
        Musica.GetComponent<AudioSource>().Play();
        other.GetComponent<Animator>().enabled=true;
        other.GetComponent<MovimientoPersonaje>().enabled=true;
        StartCoroutine(area.GetComponent<Area>().ShowArea(name));
    }


    // Dibujaremos un cuadrado con opacidad encima de la pantalla simulando una transición
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
