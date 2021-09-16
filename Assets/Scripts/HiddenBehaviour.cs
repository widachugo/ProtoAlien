using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenBehaviour : MonoBehaviour
{
    public Image currentResearch;

    public bool playerOnHidden;
    public bool alienSearch;
    public bool researchFinished;

    private float tSearch;

    private void Update()
    {
        if (alienSearch)
        {
            tSearch += Time.deltaTime;
        }
        else
        {
            tSearch -= Time.deltaTime;
        }
        tSearch = Mathf.Clamp(tSearch, 0, 1);

        currentResearch.fillAmount = Mathf.Lerp(0, 1, tSearch);

        if (currentResearch.fillAmount >= 1)
        {
            researchFinished = true;
        }
        else
        {
            researchFinished = false;
        }
    }
}
