using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Setting_3C setting3C = null;
    public GameManager gameManager = null;

    Player player;

    int combo = 0;

    void Awake() {
        player = this.gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlayerDead()) {
            return;
        }

        Vector3 playerMeshCenter = this.transform.GetChild(0).position;
        Vector3 playerMeshBottom = this.transform.position; // anchor point is (0.5, 0.0)
        Vector3 lineCast_Endpoint = playerMeshBottom - new Vector3(0.0f, 0.1f, 0.0f);

        RaycastHit hitTarget;
        if (Physics.Linecast(playerMeshCenter, lineCast_Endpoint, out hitTarget)) {
            if (!player.isPlayerLanded()) {
                LandedOnBlock(hitTarget.transform.GetComponent<Block>());
            }
        }
        else {
            player.setLanded(false);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                if (player.isPlayerLanded()) {
                    this.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, setting3C.jumpForce, 0.0f));
                }
            }
        }
        else if(Input.GetButtonDown("Fire1")) {
            if (player.isPlayerLanded()) {
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, setting3C.jumpForce, 0.0f));
            }
        }
    }

    void LandedOnBlock(Block block)
    {
        player.setLanded(true);

        if (block != null) {
            if(block.isPerfectLanded()) {
                combo++;
                if(combo > player.streak) {
                    player.streak++;
                    combo = 0;
                }
            }
            else {
                player.streak = 0;
            }
            block.Hit();
            GameManager.instance.AddScore(1 + player.streak);
        }
    }

    public void Dead(int side)
    {
        player.setDead(true);
        Destroy(this.GetComponent<Collider>());
        this.GetComponent<Rigidbody>().AddForce(new Vector3(side * setting3C.deadForce, 0.0f, 0.0f));
    }
}
