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
        //因為是使用translate所以可以使用世界座標進行方向上的移動
        transform.Translate(-0.01f, 0, 0,Space.World);
        Vector2 limiteXY = cameraPoint.ComputeCamera(transform.position);
        if (transform.position.x > limiteXY.x || transform.position.x < limiteXY.x)
        {
            enemyPool.ReturnObject(gameObject);
        }


    }
    // 當觸發器開始時調用
    void OnTriggerEnter2D(Collider2D enemy)
    {
        // 檢查碰撞物體是否具有標籤 "Player"
        if (enemy.CompareTag("Player") || enemy.CompareTag("Bullet"))
        {
            //Destroy(gameObject);
            enemyPool.ReturnObject(gameObject);
        }
    }
}
