using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    
    private Rigidbody2D R2D;
    [Range(15, 16)] public byte startForce;

    public bool harmful;


    private void Awake()
    {
        R2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        R2D.AddForce(Vector2.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);

      
        if (!harmful)
        {
            GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score += 10;
        }
        else
        {
            GameObject.Find("LifeCounter").transform.GetComponent<LifeCounter>().LoseLife();
        }
    }

}
