using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //on trigger, stop the game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //store collision with blade in a var
        Blade b = collision.GetComponent<Blade>();

        //if no collision detected, nothing, otherwise call method that stop the game
        if(!b) return;

        FindObjectOfType<GameManager>().OnBombHit();

    }
}
