using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSBulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 5f;
    private CameraControl cameraPoint; //導入鏡頭位移計算
    private BOSSBulletPool BOSSBulletPool;
    private Rigidbody2D rb;          // 角色的 Rigidbody2D

    void Start()
    {
        // 初始化 cameraPoint
        cameraPoint = FindObjectOfType<CameraControl>();
        // 獲取對象池,有點像是建立建構子
        BOSSBulletPool = FindObjectOfType<BOSSBulletPool>();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("BOSSBulletControl");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-bulletSpeed, 0); // 吃的是世界座標
        OutOfRange();
    }

    void OutOfRange()
    {
        Vector2 limiteXY = cameraPoint.ComputeCamera(transform.position);
        if (transform.position.x > limiteXY.x || transform.position.x < limiteXY.x)
        {
            BOSSBulletPool.ReturnObject(gameObject); // 將子彈歸還到池中
        }
    }
}
