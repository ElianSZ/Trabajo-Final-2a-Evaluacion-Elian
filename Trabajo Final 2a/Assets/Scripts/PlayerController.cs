using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // private Vector3 initialPos = new Vector3(0, 100, 0);
     public float speed = 4f;
     public float runSpeed = 7f;
     public float rotSpeed = 40f;
     public float rot = 0f;

    // public float graviy = 0f;
    public Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    private Animator anim;

    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;
    public GameObject shooter1;
    public GameObject shooter2;
    public GameObject explosion;

    public ParticleSystem explosionParticleSystem;
    public ParticleSystem explosionParticleSystem2;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    /*
    public int kills;
    public TextMeshProUGUI killsText;
    */

    //In the editor, add your wayPoint gameobject to the script.
    public GameObject wayPoint;
    //This is how often your waypoint's position will update to the player's position
    private float timer = 0.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        // playerAudioSource = GetComponent<AudioSource>();
        // UpdateKills(0);
        // kills = 0;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // killsText.text = $"Kills: {kills}";

        Movement();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Se dispara el proyectil 1
            Instantiate(projectilePrefab, shooter1.transform.position, transform.rotation);
            Instantiate(explosionParticleSystem, shooter1.transform.position, transform.rotation);

            // Se dispara el proyectil 2
            Instantiate(projectilePrefab2, shooter2.transform.position, transform.rotation);
            Instantiate(explosionParticleSystem, shooter2.transform.position, transform.rotation);

            // Ejecuta una vez el audio de disparo
            // playerAudioSource.PlayOneShot(shotClip, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(25);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            //The position of the waypoint will update to the player's position
            UpdatePosition();
            timer = 0.5f;
        }
    }

    private void Movement()
    {
        // Caminar
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Walk", 1);

            moveDir = new Vector3(0, 0, 1);
            moveDir = moveDir * speed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("Walk", 0);

            moveDir = new Vector3(0, 0, 0);
        }

        // Correr
        if (Input.GetKey (KeyCode.LeftShift))
        {
            anim.SetInteger("Run", 1);

            moveDir = new Vector3(0, 0, 1);
            moveDir = moveDir * runSpeed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetInteger("Run", 0);

            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(moveDir * Time.deltaTime);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void OnCollisionEnter(Collision otherCollider)
    {
        // Si colisiona con un obstacle, destruye ambos objetos
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            // kills = kills + 1;
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            Instantiate(explosionParticleSystem2, shooter1.transform.position, transform.rotation);
        }
    }

    void UpdatePosition()
    {
        //The wayPoint's position will now be the player's current position.
        wayPoint.transform.position = transform.position;
    }

    /*
    // Indica que los kills se actualizan con los puntos obtenidos
    public void UpdateKills(int pointsToAdd)
    {
        kills += pointsToAdd;
        killsText.text = $"Kills: {kills}";
    }
    */
}