using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLevel2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CardUnlock>().cardLevel2 = true;
            Destroy(gameObject);
        }
    }
}
