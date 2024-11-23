using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    bool gameOver;

    void Start() {
        FindObjectOfType<PlayerController> ().onPlayerDeath += OnGameOver;
    }

    void Update() {
        if (gameOver) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver() {
        gameOverScreen.SetActive(true);
        gameOver = true;
    }
}
