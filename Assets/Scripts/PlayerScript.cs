using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health = 3;
    private float moveSpeed = 5f;
    private float jumpForce = 4f;
    [SerializeField] GameObject door;
    [SerializeField] GameLogicScript logic;
    [SerializeField] Collider2D enemy;

    private void Awake()
    {
        door = GameObject.FindGameObjectWithTag("Finish");
        logic = GameObject.Find("GameLogicManager").GetComponent<GameLogicScript>();
        enemy = GameObject.Find("Enemy").GetComponent<Collider2D>();
        logic.healthText.text = health.ToString();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            logic.LoseGame();
        }
    }

    void FixedUpdate()
    {
        MovementInputForPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == door)
        {
            logic.WinGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            logic.healthText.text = health.ToString();
        }
    }

    void MovementInputForPlayer()
    {
        //move on y
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.down * jumpForce * Time.deltaTime);
        }
        //move on x
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}
