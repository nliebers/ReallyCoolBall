using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    private GameObject[] eggs;

    void Start()
    {
        eggs = GameObject.FindGameObjectsWithTag("PickUp");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject egg = eggs[Random.Range(0, eggs.Length)];
        if (egg.activeSelf) {
            egg.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)));
        }
    }
}
