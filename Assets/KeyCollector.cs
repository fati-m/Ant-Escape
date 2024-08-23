using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeyCollector : MonoBehaviour
{
    public int keysCollected = 0;
    public int totalKeys = 4;
    public Text keyText;
    public Text gameMessage;
    public GameObject replayButton;

    void Start()
    {
        UpdateKeyText();
        StartCoroutine(DisplayStartMessage());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            // Disable the collider to prevent multiple triggers
            other.GetComponent<Collider>().enabled = false;

            keysCollected++;
            Destroy(other.gameObject);
            UpdateKeyText();

            if (keysCollected >= totalKeys)
            {
                StartCoroutine(GameOver("Game over: You survived the killer ant!"));
            }
        }
        else if (other.CompareTag("EnemyAnt"))
        {
            StartCoroutine(GameOver("Game over: The killer ant got you!"));
        }
    }

    void UpdateKeyText()
    {
        keyText.text = "Keys collected: " + keysCollected + "/" + totalKeys;
    }

    IEnumerator DisplayStartMessage()
    {
        gameMessage.text = "Goal: Collect all four keys without running into the killer ant.";
        yield return new WaitForSeconds(2);
        gameMessage.text = ""; // Clear the message after 2 seconds
    }

    IEnumerator GameOver(string message)
    {
        gameMessage.text = message;
        yield return new WaitForSeconds(2);

        Time.timeScale = 0f; // Stop the game
        replayButton.SetActive(true); // Show the replay button
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f; // Resume game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
