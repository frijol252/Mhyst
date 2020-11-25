using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CharacterSelection : MonoBehaviour
{
    public GameObject personaje;
    public PlayableDirector Directore;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Canvas selected; 
    // Start is called before the first frame update
    void Start()
    {
        Directore.Pause();
        personaje.GetComponent<MovimientoPersonaje>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCharacter(Sprite newSprite){

        spriteRenderer.sprite = newSprite; 
    }
    public void animacion(RuntimeAnimatorController a){
        animator.runtimeAnimatorController = a as RuntimeAnimatorController;
        selected.enabled = false;
        Directore.enabled=true;
        Directore.Play();
    }
}
