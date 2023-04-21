using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Target")]
    public GameObject prefab;

    public float interval;
    public float minX;
    public float maxX;
    public float y;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(Random.Range(minX, maxX), y);

        instance.transform.SetParent(transform);

        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
