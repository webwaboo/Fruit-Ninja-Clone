using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //var that will use this and be affected by this script
    public GameObject[] fruitToSpawn;
    
    //interval of time for fruit spawning
    public float minWait = .3f;
    public float maxWait = 1f;

    //position of spawner
    public Transform[] spawnPlaces;

    //ejection force min/max
    public float minForce = 12;
    public float maxForce = 17;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    //used to call method multiple times in coroutine
    private IEnumerator SpawnFruits()
    {
        //while coroutine runs
        while (true)
        {
            //return debug in interval of time of minmax wait
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            //spawn place (=t) will be attributed randomly among those available thanks the array and random
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            //empty gameobject for our future fuit
            GameObject go = null;
            //random nuimber that will define the object that'll spawned
            float p = Random.Range(0, 100);
            //we use if to choose wich object get spawned
            if(p < 10)
            {
                go = fruitToSpawn[0];
            }
            else
            {
                go = fruitToSpawn[Random.Range(1, fruitToSpawn.Length)];
            }
            
            //instantiate the fruit (go) at the position t
            GameObject fruit = Instantiate(go, t.position, t.rotation);

            //add force to fruit when it instantiates from spawn place
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce), ForceMode2D.Impulse);
            
            Debug.Log("fruits get spawned");

            //destroy fruit after 5 sec
            Destroy(fruit, 5);
        }
    }
}
