using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float speed;

    private CharacterController controller;
    private Vector3 move = Vector3.zero;

    public GameManager gameManager;

    public float cooldownAttack;

    public bool canAttack;

    private bool stun;
    public float coolDownStun;

    public Material matIni;
    public Material matStun;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Mouvements
        if (!stun)
        {
            move = new Vector3(Input.GetAxis("HorizontalAlien"), Input.GetAxis("VerticalAlien"), 0);
            controller.Move(move * speed * Time.deltaTime);
        }

        Physics.IgnoreLayerCollision(8,9);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && canAttack)
        {
            StartCoroutine(Attack(other.gameObject));
        }

        if (other.gameObject.tag == "Hidden")
        {
            other.gameObject.GetComponentInParent<HiddenBehaviour>().alienSearch = true;
        }

        if (other.gameObject.tag == "Trap")
        {
            StartCoroutine(Stun());
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Flame")
        {
            StartCoroutine(Stun());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hidden")
        {
            other.gameObject.GetComponentInParent<HiddenBehaviour>().alienSearch = false;
        }
    }

    private IEnumerator Attack(GameObject player)
    {
        canAttack = false;
        player.GetComponent<Player>().TakeDamage(1);
        yield return new WaitForSeconds(cooldownAttack);
        canAttack = true;
    }

    private IEnumerator Stun()
    {
        stun = true;

        gameObject.GetComponent<SpriteRenderer>().material = matStun;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matIni;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matStun;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matIni;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matStun;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matIni;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matStun;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matIni;

        yield return new WaitForSeconds(coolDownStun);
        stun = false;
    }
}
