using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOControl : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyPool enemyPool;
    private CameraControl cameraPoint;
    void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();
        cameraPoint = FindObjectOfType<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //�]���O�ϥ�translate�ҥH�i�H�ϥΥ@�ɮy�жi���V�W������
        transform.Translate(-0.01f, 0, 0,Space.World);
        Vector2 limiteXY = cameraPoint.ComputeCamera(transform.position);
        if (transform.position.x > limiteXY.x || transform.position.x < limiteXY.x)
        {
            enemyPool.ReturnObject(gameObject);
        }


    }
    // ��Ĳ�o���}�l�ɽե�
    void OnTriggerEnter2D(Collider2D enemy)
    {
        // �ˬd�I������O�_�㦳���� "Player"
        if (enemy.CompareTag("Player") || enemy.CompareTag("Bullet"))
        {
            //Destroy(gameObject);
            enemyPool.ReturnObject(gameObject);
        }
    }
}
