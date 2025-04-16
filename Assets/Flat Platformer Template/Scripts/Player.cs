using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float WalkSpeed;
    public float JumpForce;
    public AnimationClip _walk, _jump;
    public Animation _Legs;
    public Transform _Blade;
    public bool mirror = false;
    private Rigidbody2D rig;
    private Vector2 _inputAxis;
    private bool isGrounded = false;
    [SerializeField] GameObject body;
    [SerializeField] GameObject leg0;
    [SerializeField] GameObject leg1;
    [SerializeField] GameLogicScript health;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rig = GetComponent<Rigidbody2D>();
        body = GameObject.Find("Body");
        leg0 = GameObject.Find("Leg0");
        leg1 = GameObject.Find("Leg1");
        health = GameObject.Find("GameLogicManager").GetComponent<GameLogicScript>();
    }

    void Update()
    {
        // Get input for walking (A/D or Left/Right arrow keys)
        _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), 0); // Only horizontal movement

        // Jumping input (W key)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            Jump();
        }

        // Update mirror value based on horizontal input direction (flipping sprite)
        if (_inputAxis.x > 0)
        {
            mirror = false;  // Player is facing right
        }
        else if (_inputAxis.x < 0)
        {
            mirror = true;   // Player is facing left
        }

        FollowMouse();
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rig.velocity = new Vector2(_inputAxis.x * WalkSpeed, rig.velocity.y); // Update horizontal velocity

        // Flip the player sprite based on mirror value
        if (mirror)
        {
            // Flip the sprite by changing the localScale only on the X axis (affects only the sprite renderer)
            body.GetComponent<SpriteRenderer>().flipX = true;
            leg0.GetComponent<SpriteRenderer>().flipX = true;
            leg1.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            // Reset the sprite flipping
            body.GetComponent<SpriteRenderer>().flipX = false;
            leg0.GetComponent<SpriteRenderer>().flipX = false;
            leg1.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Play walking animation if moving
        if (_inputAxis.x != 0)
        {
            _Legs.clip = _walk;
            _Legs.Play();
        }
        else
        {
            _Legs.Stop(); // Stop animation if no horizontal movement
        }
    }

    void Jump()
    {
        // Apply upward force to the Rigidbody for jumping
        rig.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        // Play jump animation
        _Legs.clip = _jump;
        _Legs.Play();
    }

    // Simple ground check using a small overlap circle at the player's feet
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is touching something tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is grounded
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            health.healthText.text = (int.Parse(health.healthText.text) - 1).ToString();
        }
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the player is touching something tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is grounded
        }
    }

    // When the player stops touching the ground, we disable the jump ability
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Player is no longer grounded
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Door")
        {
            health.WinGame();
        }
    }

    void FollowMouse()
    {
        // Get the mouse position in world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Ensure the mouse position is in the same Z plane as the blade
        mouseWorldPosition.z = _Blade.position.z;  // Keep the blade's z position unchanged

        // Get the direction from the player to the mouse (relative to the player)
        Vector3 direction = mouseWorldPosition - _Blade.position;
        direction.Normalize();  // Normalize to only use direction

        // Calculate the angle to rotate the blade towards the mouse cursor
        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _Blade.rotation = Quaternion.AngleAxis(rot, Vector3.forward);  // Rotate the blade
    }
}