using System.Collections;
using UnityEngine;

public class SlimeEnemyScrip : MonoBehaviour
{
    public GameObject projectile;

    void Start()
    {
        StartCoroutine("SpawnProjectile");
    }

    private IEnumerator SpawnProjectile()
    {
        while (Time.timeScale != 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(6f);
        }
    }
}
