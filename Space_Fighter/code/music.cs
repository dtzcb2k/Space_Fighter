using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip backgroundMusic; // 背景音樂檔案
    public AudioClip BOSS_battle;
    private AudioSource audioSource;
    public GameObject BOSS;
    private CameraControl cameraPoint;
    private bool bossMusicPlaying = false;

    void Start()
    {
        // 添加 AudioSource 並設置屬性
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // 使音樂循環
        audioSource.Play(); // 播放音樂
        cameraPoint = FindObjectOfType<CameraControl>();
    }


    public void BOSSBattle()
    {
        audioSource.Stop();
        audioSource.clip = BOSS_battle;
        audioSource.loop = true;
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 rightX = cameraPoint.GetRightEdgePosition();
        if (rightX.x > BOSS.transform.position.x && !bossMusicPlaying)
        {
            bossMusicPlaying = true; // 標記為已切換音樂
            BOSSBattle(); // 播放BOSS戰音樂
        }
    }
}
