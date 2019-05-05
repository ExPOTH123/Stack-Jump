using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public Setting_Level settingLevel = null;

    int childCount = 1;
    GameObject block = null;

    CameraManager cameraManager = null;

    // Use to spawn on beat
    public float spawnThrehold = 0.002f;
    public int fromFrequency = 700;
    public int toFrequency = 800;
    public FFTWindow ffTWindow;

    private float[] samples = new float[1024];
    // end

    float spawnTime = 2.0f;
    float timeCount = 0.0f;

    void Awake()
    {
        block = this.transform.GetChild(0).gameObject;
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }

    void Update() {
        timeCount += Time.deltaTime;
        
        resetFrequency();
        AudioListener.GetSpectrumData(samples, 0, ffTWindow);

        if(timeCount >= spawnTime){
            if(checkFrequency()) {
                Spawn();
                timeCount = 0;
            }
        }
       
    }

    bool checkFrequency() {
        for(int i = fromFrequency; i < toFrequency; i++) {
           if(samples[i] > spawnThrehold) {
               return true;
           }
        }

        return false;
    }

    void resetFrequency() {
        for(int i = fromFrequency; i < toFrequency; i++) {
            samples[i] = 0;
        }
    }

    public void Spawn() {
        int side = Random.Range(0, 2);
        side = (side == 1)? 1:-1;
        block = Instantiate(block, new Vector3(side * 4.0f, childCount + 0.5f, 0.0f), Quaternion.identity) as GameObject;
        childCount++;

        block.transform.parent = this.transform;
        block.gameObject.name = "Block";
        float speed = Random.Range(settingLevel.minSpeed, settingLevel.maxSpeed);
        block.GetComponent<Block>().SetSpeed(speed);

        cameraManager.MoveCameraUp();
        
        if(this.transform.childCount > 20) {
            Destroy(this.transform.GetChild(0).gameObject);
        }
    }

    public void GameOver() {
        cameraManager.GameOverCameraAnimation();
    }
}
