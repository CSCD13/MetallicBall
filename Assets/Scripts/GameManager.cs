using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private int score = 0;
    private int totalCollectibles;
    private const string COLLECTIBLE_TAG = "Collectible";
    private const string WIN_SCREEN = "WIN SCREEN";

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        totalCollectibles = GameObject.FindGameObjectsWithTag(COLLECTIBLE_TAG).Length;
        scoreText.text = "Counter: 0/" + totalCollectibles;
    }

    public void addScore() {
        score++;
        scoreText.text = "Counter: " + score + "/" + totalCollectibles;

        if (score == totalCollectibles) {
            SceneManager.LoadScene(WIN_SCREEN);
        }
    }
}