using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharer : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer enemy;

    public static SpriteRenderer Player;
    public static SpriteRenderer Enemy;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Player = player;
        Enemy = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
