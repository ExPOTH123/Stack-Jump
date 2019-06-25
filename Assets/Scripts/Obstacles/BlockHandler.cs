using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public Setting_Level settingLevel = null;

    public AudioSource audioSource;

    int childCount = 1;
    GameObject block = null;

    CameraManager cameraManager = null;

    // Use to spawn on beat
    public float spawnThrehold = 0.002f;
    public int fromFrequency = 700;
    public int toFrequency = 800;
    public FFTWindow ffTWindow;

    public float[] samples = new float[1024];
    private float[] previousSamples = new float[1024];
    // end

    float spawnTime = 0.5f;
    float timeCount = 0.0f;
    
    
    bool isFirstBlock = true;

    void Awake()
    {
        block = this.transform.GetChild(0).gameObject;
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    void Update() {
        timeCount += Time.deltaTime;
        
        // resetFrequency();
        audioSource.GetSpectrumData(samples, 0, ffTWindow);
        // Debug.Log(AudioSettings.dspTime);

        if(checkFrequency()) {
            if(timeCount >= spawnTime){
                Spawn();
                timeCount = 0;
            }
        }
    }

    bool checkFrequency() {
        float maxPeak = 0;
        for(int i = fromFrequency; i < toFrequency; i++) {
           if(samples[i] - previousSamples[i] > maxPeak) {
               maxPeak = samples[i] - previousSamples[i];
           }
               Debug.DrawLine(new Vector3(i, 0, 0), new Vector3(i, 100 * samples[i], 0));

            // maxPeak += samples[i];

           previousSamples[i] = samples[i];
        }

        // float avg = maxPeak - previousAvg;
        // previousAvg = maxPeak;
        
        if(maxPeak > spawnThrehold) {
            Debug.Log(maxPeak);
            return true;
        }

        return false;
    }

    void resetFrequency() {
        for(int i = fromFrequency; i < toFrequency; i++) {
            samples[i] = 0;
        }
    }

    public void Spawn() {
        if(isFirstBlock) {
            isFirstBlock = false;
            return;
        }
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
