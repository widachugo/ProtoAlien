using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLevel1 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CardUnlock>().cardLevel1 = true;
            Destroy(gameObject);
        }
    }
}
