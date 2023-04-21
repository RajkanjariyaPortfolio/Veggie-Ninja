using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vegetable : MonoBehaviour
{
    [SerializeField] private GameObject slice;
    private Rigidbody2D R2D;
    [Range(15, 16)] public byte startForce;
    public ScoreText scoretext;
    public LifeCounter lifeCounter;

    public bool harmful;
    [SerializeField]
    ScoreXp scoreXp;
   
    private void Awake()
    {
        R2D = GetComponent<Rigidbody2D>();
        scoretext = GameObject.Find("ScoreText").transform.GetComponent<ScoreText>();
        lifeCounter=GameObject.Find("LifeCounter").transform.GetComponent<LifeCounter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        R2D.AddForce(Vector2.up * startForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var cut = Instantiate(slice, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        cut.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(2, 5), ForceMode2D.Impulse);

        //cut.hideFlags = HideFlags.HideInHierarchy;
        if (!harmful)
        {
            scoreXp.score += 10;
            scoretext.Score += 10;

        }
        else
        {
            lifeCounter.LoseLife();
        }
    }
}
