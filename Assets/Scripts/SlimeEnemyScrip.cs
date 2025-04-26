using System.Collections;
using UnityEngine;

public class SlimeEnemyScrip : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gameOverScreen;

    void Start()
    {
        StartCoroutine("SpawnProjectile");
    }

    void Update()
    {
        if (gameOverScreen.activeInHierarchy == true && gameOverScreen != null)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator SpawnProjectile()
    {
        while (true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(6f);
        }
    }
}
