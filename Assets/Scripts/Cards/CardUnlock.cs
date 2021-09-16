using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUnlock : MonoBehaviour
{
    public bool cardLevel1;
    public bool cardLevel2;
    public bool cardLevel3;

    private void Update()
    {
        if (cardLevel1)
        {
            Physics.IgnoreLayerCollision(10, 14);
        }
        if (cardLevel2)
        {
            Physics.IgnoreLayerCollision(10, 15);
        }
        if (cardLevel3)
        {
            Physics.IgnoreLayerCollision(10, 16);
        }
    }
}
