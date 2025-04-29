using System.Collections;
using UnityEngine;

public class BossPowerScript : MonoBehaviour
{
    public GameObject slime;
    SpriteRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        StartCoroutine("SpawnSlimes");
    }

    public IEnumerator SpawnSlimes()
    {
        while (true)
        {
            yield return new WaitForSeconds(9f);
            renderer.enabled = true;
            Instantiate(slime, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            renderer.enabled = false;
        }
    }
}
