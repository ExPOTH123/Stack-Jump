using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    int childCount = 1;
    GameObject block = null;

    CameraManager cameraManager = null;

    // Start is called before the first frame update
    void Awake()
    {
        block = this.transform.GetChild(0).gameObject;
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }

    public void Spawn() {
        int side = Random.Range(0, 2);
        side = (side == 1)? 1:-1;
        block = Instantiate(block, new Vector3(side * 4.0f, childCount + 0.5f, 0.0f), Quaternion.identity) as GameObject;
        childCount++;
        block.transform.parent = this.transform;
        block.gameObject.name = "Block";
        cameraManager.MoveCameraUp();
        if(this.transform.childCount > 20) {
            Destroy(this.transform.GetChild(0).gameObject);
        }
    }

    public void GameOver() {
        cameraManager.GameOverCameraAnimation();
    }
}
