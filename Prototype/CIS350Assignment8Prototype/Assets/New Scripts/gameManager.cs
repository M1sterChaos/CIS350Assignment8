/*
 * (Austin Buck)
 * (Assignment 8)
 * (Controls the game and score)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public List<GameObject> targets;

    private float spawnRate = 1f;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI goText;

    public bool gameOver = false;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());

        scoreText.text = "Score: " + score;
        goText.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        goText.text = "Game Over \nPress R to Restart!";
        goText.gameObject.SetActive(true);

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while(gameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
