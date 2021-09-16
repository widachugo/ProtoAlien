using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public GameObject trapItem;

    private CharacterController controller;
    private Vector3 move = Vector3.zero;

    private bool goal;

    public GameManager gameManager;

    private bool playerOnHidden;
    private float tHide;
    public HiddenBehaviour currentHidden;

    //partie vie du joueur
    public int maxHealth = 3;
    public int currentHealth;

    public HealthBarScript healthBar;

    public GameObject flameThrowerOrigin;

    public GameObject currentAlien;

    public Material matIni;
    public Material matDamage;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        //partie vie du joueur
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    private void Update()
    {
        //Mouvements
        move = new Vector3(Input.GetAxis("HorizontalPlayer"), Input.GetAxis("VerticalPlayer"), 0);
        controller.Move(move * speed * Time.deltaTime);

        Physics.IgnoreLayerCollision(10, 11);

        if (playerOnHidden && currentHidden != null && !currentHidden.researchFinished)
        {
            tHide += Time.deltaTime;
        } 
        else if (playerOnHidden && currentHidden != null && currentHidden.researchFinished)
        {
            transform.position = new Vector3(currentHidden.transform.position.x, currentHidden.transform.position.y - 1, transform.position.z);
        }
        else
        {
            tHide -= Time.deltaTime;
        }

        tHide = Mathf.Clamp(tHide, 0, 1);
        SpriteRenderer spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.material.color = new Color(spriteRenderer.material.color.r, spriteRenderer.material.color.g, spriteRenderer.material.color.b, Mathf.Lerp(1, 0, tHide));

        if (currentHealth <= 0)
        {
            gameManager.DeathPlayer();
        }

        if (Input.GetKeyDown(KeyCode.A) && gameManager.trap > 0)
        {
            Instantiate(trapItem, transform.position, trapItem.transform.rotation);
            gameManager.trap--;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            flameThrowerOrigin.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            flameThrowerOrigin.SetActive(false);
        }

        flameThrowerOrigin.transform.LookAt(currentAlien.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            goal = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Finish" && goal)
        {
            gameManager.Victory();
        }

        if (other.gameObject.tag == "Hidden")
        {
            playerOnHidden = true;
            other.gameObject.GetComponentInParent<HiddenBehaviour>().playerOnHidden = true;
            currentHidden = other.gameObject.GetComponentInParent<HiddenBehaviour>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hidden")
        {
            playerOnHidden = false;
            other.gameObject.GetComponentInParent<HiddenBehaviour>().playerOnHidden = false;
            currentHidden = null;
        }
    }


    //partie vie du joueur
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        StartCoroutine(DamageEffect());
    }

    private IEnumerator DamageEffect()
    {
        gameObject.GetComponent<SpriteRenderer>().material = matDamage;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matIni;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matDamage;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matIni;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matDamage;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matIni;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matDamage;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().material = matIni;
    }

}
