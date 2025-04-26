using UnityEngine;
using UnityEngine.UI;

public class SlimeProjectileScript : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text health;
    private float speed = 4f;
    Vector3 direction;

    void Awake()
    {
        player = GameObject.Find("Knight").GetComponent<Player>();
        direction = player.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        MoveProjectile();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundry"))
        {
            Destroy(gameObject);
        }
    }

    void MoveProjectile()
    {
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
