using UnityEngine;

public class SlimeProjectileScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] GameObject projectile;
    private float speed = 4f;

    void Awake()
    {
        projectile = gameObject;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.health--;
            Destroy(projectile);
        }
    }

    void MoveProjectile()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
