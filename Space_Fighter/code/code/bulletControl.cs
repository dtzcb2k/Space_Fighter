using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 0.03f;
    private CameraControl cameraPoint; //導入鏡頭位移計算
    private bullletPool bullletPool;
    void Start()
    {
        // 初始化 cameraPoint
        cameraPoint = FindObjectOfType<CameraControl>();
        // 獲取對象池,有點像是建立建構子
        bullletPool = FindObjectOfType<bullletPool>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletSpeed, 0, 0,Space.World);
        OutOfRange();
    }
    void OnTriggerEnter2D(Collider2D Bullet)
    {
        if (gameObject.CompareTag("Bullet")) //player射出的子彈
        {
            if (Bullet.CompareTag("Enemy") || Bullet.CompareTag("BOSS"))
            {
                bullletPool.ReturnObject(gameObject); // 將子彈歸還到池中
            }
        }
        else if (gameObject.CompareTag("BOSS")){ //BOSS發射的子彈
            if (Bullet.CompareTag("Player"))
            {
                bullletPool.ReturnObject(gameObject); // 將子彈歸還到池中
            }
        }
        
    }
    void OutOfRange()
    {
        Vector2 limiteXY = cameraPoint.ComputeCamera(transform.position);
        if (transform.position.x > limiteXY.x || transform.position.x < limiteXY.x)
        {
            bullletPool.ReturnObject(gameObject); // 將子彈歸還到池中
        }
    }
}
