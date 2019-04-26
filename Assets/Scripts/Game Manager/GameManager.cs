using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Setting_Game settingGame = null;
    public GameObject player = null;

    Player playerComp;

    bool isGameOver = false;

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
}
