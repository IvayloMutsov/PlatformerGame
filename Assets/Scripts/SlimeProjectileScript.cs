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

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveProjectile();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health.text = (int.Parse(health.text) - 1).ToString();
            Destroy(gameObject);
        }
    }

    void MoveProjectile()
    {
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
