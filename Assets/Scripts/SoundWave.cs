using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundWave : MonoBehaviour
{
    public GameObject player;
    public GameObject arrow;

    public float coolDown;

    private void Start()
    {
        //StartCoroutine(Detection());
    }

    public void Update()
    {
        //Debug.Log(player.transform.position);
        transform.LookAt(player.transform.position);

        //Vector3 dir = player.transform.position - transform.position;

        //float angle = Vector3.Angle(player.transform.position - transform.position, transform.forward);

        //Vector3 targetDir = player.transform.position - transform.position;
        //Vector3 forward = transform.forward;
        //float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);

        //Debug.Log(angle);

    }

    public IEnumerator Detection()
    {
        arrow.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        arrow.SetActive(false);
        yield return new WaitForSeconds(coolDown);

        StartCoroutine(Detection());
    }
}
