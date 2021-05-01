using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public bool PlayerDead;
    public bool EnemyDead;

    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI DeathText;
    private int x;
    public GameObject gameOver;
    private void Start()
    {
        gameOver.gameObject.SetActive(false);
        PlayerDead = false;
        EnemyDead = false;
    }

    public void death(int y)
    {
        gameOver.gameObject.SetActive(true);
        if (y==1)
        {
            PlayerDead = true;
            DeathText.text = "PLAYER DEAD";
            buttonText.text = "RETRY";
            x = SceneManager.GetActiveScene().buildIndex;
            Time.timeScale = 3;
        }
        if (y==2)
        {
            EnemyDead = true;
            DeathText.text = "CONGRATULATIONS";
            buttonText.text = "NEXT LEVEL";
            x = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }

    public void Die()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(x);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
