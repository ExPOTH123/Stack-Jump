using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Setting_Game settingGame = null;
    public GameObject player = null;

    Player playerComp;

    public Text scoreText;

    int score = 0;

    bool isGameOver = false;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    void Start() {
        playerComp = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver) {
            return;
        }

        if(playerComp.isPlayerDead()) {
            isGameOver = true;
            Invoke("LoadGameOver", settingGame.waitGameOver);
        }
    }

    void LoadGameOver() {
        SceneManager.LoadScene("GameOver");;
    }

    public void AddScore(int score_In) {
        score += score_In;

        scoreText.text = score.ToString();
    }
}
