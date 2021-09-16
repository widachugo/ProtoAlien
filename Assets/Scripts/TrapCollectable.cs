using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollectable : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.trap += 2;
            Destroy(gameObject);
        }
    }
}
