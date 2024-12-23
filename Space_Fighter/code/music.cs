using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip backgroundMusic; // �I�������ɮ�
    public AudioClip BOSS_battle;
    private AudioSource audioSource;
    public GameObject BOSS;
    private CameraControl cameraPoint;
    private bool bossMusicPlaying = false;

    void Start()
    {
        // �K�[ AudioSource �ó]�m�ݩ�
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // �ϭ��ִ`��
        audioSource.Play(); // ���񭵼�
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
            bossMusicPlaying = true; // �аO���w��������
            BOSSBattle(); // ����BOSS�ԭ���
        }
    }
}
