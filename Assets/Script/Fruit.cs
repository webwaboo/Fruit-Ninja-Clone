using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //var that will use this and be affected by this script
    public GameObject slicedFruitPrefab;

    //call the createslicedFruit function when space is pressed
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSlicedFruit();
        }*/
    }

    //fonction that change fruit into sliced fruit
    public void CreateSlicedFruit()
    {
        //create the sliced fruit at same position of original object and save it in a var
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        //put 2 parts of the fruits in array
        Rigidbody[] rbsOnSliced = inst.GetComponentsInChildren<Rigidbody>();

        //rotate the 2 sliced parts and make them explode
        foreach(Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(50, 100), transform.position, 5f);
        }

        //increase score with gamemanager fonction
        FindObjectOfType<GameManager>().IncreaseScore(3);
        
        //destroy gameobject
        Destroy(inst.gameObject, 5);
        Destroy(gameObject);
    }

    //on triggger, cut fruit in slices
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //store collision with blade in a var
        Blade b = collision.GetComponent<Blade>();

        //if no collision detected, nothing, otherwise create slice
        if (!b)
        {
            return;
        }
        CreateSlicedFruit();
    }
}