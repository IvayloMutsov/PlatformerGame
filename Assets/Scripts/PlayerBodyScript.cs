using UnityEngine;

public class PlayerBodyScript : MonoBehaviour
{
    [SerializeField] GameLogicScript playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = GameObject.Find("GameLogicManager").GetComponent<GameLogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            playerHealth.healthText.text = (int.Parse(playerHealth.healthText.text) - 1).ToString();
            Destroy(collision.gameObject);
        }
    }
}
