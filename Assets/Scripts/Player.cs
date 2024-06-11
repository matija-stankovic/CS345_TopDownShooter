using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Canvas nextLevelCanvas;
    public Text nextLevelText;

    void Start()
    {
        currentHealth = maxHealth;

        if (nextLevelCanvas != null)
        {
            nextLevelCanvas.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            if (GameManager.instance.AreAllEnemiesDefeated())
            {
                Debug.Log("All enemies are defeated! You can proceed to the next level.");
                StartCoroutine(ProceedToLevel2());
            }
        }
        else if (other.CompareTag("Goal1"))
        {
            if (GameManager.instance.AreAllEnemiesDefeated())
            {
                Debug.Log("All enemies are defeated! You can proceed to the next level.");
                StartCoroutine(ProceedToLevel3());
            }
        }
        else if (other.CompareTag("Goal2"))
        {
            if (GameManager.instance.AreAllEnemiesDefeated())
            {
                Debug.Log("All enemies are defeated! You can proceed to the next level.");
                StartCoroutine(GameComplete());
            }
        }
    }

    private IEnumerator ProceedToLevel2()
    {
        if (nextLevelCanvas != null && nextLevelText != null)
        {
            nextLevelCanvas.gameObject.SetActive(true);
            nextLevelText.text = "Next level will start in 5 seconds...";
            yield return new WaitForSeconds(5);
            nextLevelCanvas.gameObject.SetActive(false); 
        }
        SceneManager.LoadScene("Level2");
    }

    private IEnumerator ProceedToLevel3()
    {
        if (nextLevelCanvas != null && nextLevelText != null)
        {
            nextLevelCanvas.gameObject.SetActive(true);
            nextLevelText.text = "Next level will start in 5 seconds...";
            yield return new WaitForSeconds(5);
            nextLevelCanvas.gameObject.SetActive(false); 
        }
        SceneManager.LoadScene("Level3");
    }

    private IEnumerator GameComplete()
    {
        if (nextLevelCanvas != null && nextLevelText != null)
        {
            nextLevelCanvas.gameObject.SetActive(true);
            nextLevelText.text = "Congrats! You finished TinyTanks! Returning to Main Menu...";
            yield return new WaitForSeconds(5);
            nextLevelCanvas.gameObject.SetActive(false);
        }
        SceneManager.LoadScene("StartMenu");
    }
}
