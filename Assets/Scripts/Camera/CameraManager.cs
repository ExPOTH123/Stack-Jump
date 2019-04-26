using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Setting_3C setting3C = null;

    Vector3 position;

    float speed = 10.0f;
    void Awake() {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, position, speed * Time.deltaTime);
    }

    public void MoveCameraUp() {
        position = this.transform.position + Vector3.up;
        speed = setting3C.moveUpSpeed;
    }

    public void GameOverCameraAnimation() {
        position = this.transform.position + Vector3.back * setting3C.zoomOutDistance;
        speed = setting3C.zoomOutSpeed;
    }
}
