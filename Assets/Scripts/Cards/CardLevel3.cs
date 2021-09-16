using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLevel3 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CardUnlock>().cardLevel3 = true;
            Destroy(gameObject);
        }
    }
}
