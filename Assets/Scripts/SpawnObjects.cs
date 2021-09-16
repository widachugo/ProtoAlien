using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    public Transform Spawnpoint;
    public GameObject Spawnobject;


    void Start()
    {
        SpawntheObject();
    }


    void SpawntheObject()
    {
        Instantiate(Spawnobject, Spawnpoint.transform.position, Quaternion.identity);
    }





}
