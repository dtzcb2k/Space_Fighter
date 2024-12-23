using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSControl : MonoBehaviour
{
    public Transform firePoint1;        // 子彈發射點 1
    public Transform firePoint2;        // 子彈發射點 2
    public float BOSSMoveSpeed = 5f;    // 移動速度
    public float BOSSMoveCooldown = 2f; // 移動冷卻時間
    public float fireRate = 1f;         // 子彈發射間隔
    public GameObject bulletPrefab;     // 子彈預製物件
    private float currentFireCooldown = 0f; // 當前射擊冷卻
    private BOSSBulletPool BOSSbulletPool;         // 子彈池
    private Rigidbody2D rb;                // BOSS Rigidbody2D
    private CameraControl cameraPoint;       // 主攝影機
    void Start()
    {
        BOSSbulletPool = FindObjectOfType<BOSSBulletPool>();
        rb = GetComponent<Rigidbody2D>();
        cameraPoint = FindObjectOfType<CameraControl>();
        StartCoroutine(BOSSBehavior()); // 啟動 BOSS 行為邏輯
    }

    void Update()
    {

    }

    // BOSS 行為邏輯
    private IEnumerator BOSSBehavior()
    {
        while (true)
        {
            // 移動
            yield return StartCoroutine(Movement());
            // 攻擊
            Attack();
            // 等待下一次行為
            yield return new WaitForSeconds(BOSSMoveCooldown);
        }
    }

    // 控制 BOSS 移動
    private IEnumerator Movement()
    {
        int direction = Random.Range(0, 2) == 0 ? -1 : 1; // 隨機向上或向下移動
        float moveDuration = Random.Range(1f, 3f);         // 隨機移動持續時間
        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            Vector2 newPosition = rb.position + Vector2.up * direction * BOSSMoveSpeed * Time.deltaTime;
            newPosition = cameraPoint.ComputeCamera(newPosition);
            rb.MovePosition(newPosition);
            yield return null;
        }
    }

    // 處理 BOSS 攻擊
    private void Attack()
    {
        // 攻擊冷卻計時
        currentFireCooldown -= Time.deltaTime;
        if (currentFireCooldown <= 0f)
        {
            // 發射第一發子彈
            GameObject bullet1 = BOSSbulletPool.GetObject();
            bullet1.transform.position = firePoint1.position;
            bullet1.transform.rotation = firePoint1.rotation;

            // 發射第二發子彈
            GameObject bullet2 = BOSSbulletPool.GetObject();
            bullet2.transform.position = firePoint2.position;
            bullet2.transform.rotation = firePoint2.rotation;

            currentFireCooldown = fireRate; // 重置冷卻時間
        }
    }
}
