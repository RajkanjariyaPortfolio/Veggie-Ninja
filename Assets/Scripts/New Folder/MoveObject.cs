using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    [Header("Speed")]
    public float minXSpeed;
    public float maxXSpeed;
    public float minYSpeed;
    public float maxYSpeed;

    [Header("Gameplay")]
    public float lifetime;
    public GameObject fruitSlicedPrefab;
    public GameObject cutPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2
            (
                Random.Range(minXSpeed, maxXSpeed),
                Random.Range(minYSpeed, maxYSpeed)
             );

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cut")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
			Destroy(slicedFruit,3f);
			Destroy(gameObject);
            Instantiate(cutPrefab, transform.position, Quaternion.identity);
        }
    }
}

