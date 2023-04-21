using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public int numberOfLives;

    public GameObject lifePrefab;
    public GameObject scoreTetxt;
    public GameObject gameOverGroup;

    private List<GameObject> lives;
    // Start is called before the first frame update
    void Start()
    {
        gameOverGroup.SetActive(false);

        lives = new List<GameObject>();
        for (int i =0; i < numberOfLives; i++)
        {
            GameObject lifeInstance = Instantiate(lifePrefab, transform);
            lives.Add(lifeInstance);
        }
    }

    // Update is called once per frame
  
    public void LoseLife()
    {
        numberOfLives--;
        GameObject lastLife = lives[lives.Count - 1];
        lives.Remove(lastLife);

        Destroy(lastLife);
        if(numberOfLives <= 0)
        {
           
            gameOverGroup.SetActive(true);

            Text gameOverText = gameOverGroup.GetComponentInChildren<Text>();
            int score = GameObject.Find("ScoreText").GetComponent<ScoreText>().Score;

            gameOverText.text = string.Format(gameOverText.text, score);

            scoreTetxt.SetActive(false);
        }

    }

    void Update()
    {
        if(numberOfLives <= 0 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
