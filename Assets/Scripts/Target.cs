using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private SpawnManager spawnManager;
    public int pointValue;
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
    }
    public void DeleteObject()
    {
        Destroy(gameObject); //Destroying game object after 1 sec
    }
}