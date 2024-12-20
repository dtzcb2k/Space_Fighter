using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOControl : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyPool enemyPool;
    void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.01f, 0, 0,Space.World);
        //因為是使用translate所以可以使用世界座標進行方向上的移動
        if (transform.position.x <-13)
        {
            //Destroy(gameObject);
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
