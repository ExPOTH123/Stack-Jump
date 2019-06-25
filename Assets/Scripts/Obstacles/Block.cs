using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool isPerfect = false;
    bool isMoving = true;

    float speed = 5.0f;

    BlockHandler blockHandler = null;

    // Start is called before the first frame update
    void Start()
    {
        blockHandler = this.transform.parent.GetComponent<BlockHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;
        if(isMoving) {
            this.transform.position = Vector3.MoveTowards(position, new Vector3(0.0f, position.y, position.z), speed * Time.deltaTime);
        }

        if(position.x == 0.0f) {
            isMoving = false;
            isPerfect = true;
        }
    }

    public void Hit() {
        isMoving = false;
        // blockHandler.Spawn();
    }

    public void SetSpeed(float speedIn) {
        speed = speedIn;
    }

    public bool isPerfectLanded() {
        return isPerfect;
    }

    void OnTriggerEnter (Collider other) {
        if(other.transform.parent.name == "Player") {
            if(isMoving) {
                int side = (other.transform.position.x - this.transform.position.x > 0)? 1 : -1;
                other.transform.parent.gameObject.GetComponent<PlayerInputHandler>().Dead(side);
                blockHandler.GameOver();
            }
        }
    }
}
