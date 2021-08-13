using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private DialogUI dialogUI;

    public int maxHealth = 8;
    public int currentHealth;
    public DialogUI DialogUI => dialogUI;

    public IInteractable Interactable { get; set; }

    public HealthBar healthBar;

    public float moveSpeed = 3f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //movement = new Vector2(directionX, directionY).normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (dialogUI.IsOpen) return;

        //rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.E)) // INTERACTABLE
        {
            if(Interactable != null)
            {
                Interactable.Interact(this);
            }
        }
    }

    //PLAYER HIT HEALTH 
    public void PlayerHit(int _damage)
    {
        currentHealth -= _damage;
        Debug.Log("HP: " + currentHealth);
        healthBar.SetHealth(currentHealth);
        //playerAnim.SetTrigger("Damage");

        if (currentHealth <= 0)
        {
            //playerAnim.SetTrigger("Die");
            //GameOver();
        }
    }

    //COLLISION CHECK
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            SceneManager.LoadScene("DEMO");
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}
