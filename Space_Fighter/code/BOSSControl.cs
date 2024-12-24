using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI都要導入這個

public class BOSSControl : MonoBehaviour
{
    public GameObject BOSShp;
    public int BOSShpAmount=100;
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
    private Vector2 movementDirection; // 用於存儲移動方向
    void Start()
    {
        BOSSbulletPool = FindObjectOfType<BOSSBulletPool>();
        rb = GetComponent<Rigidbody2D>();
        cameraPoint = FindObjectOfType<CameraControl>();
        StartCoroutine(BOSSBehavior()); // 啟動 BOSS 行為邏輯
    }

    void Update()
    {
        currentFireCooldown -= Time.deltaTime;
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

    void FixedUpdate()
    {
        // 計算新位置
        Vector2 horizontalMovement = Vector2.right * cameraPoint.moveSpeed * Time.fixedDeltaTime;
        Vector2 newPosition = rb.position + movementDirection * BOSSMoveSpeed * Time.fixedDeltaTime + horizontalMovement;

        // 限制移動範圍（如果需要）
        newPosition = cameraPoint.ComputeCamera(newPosition);

        // 更新 Rigidbody2D 的位置
        rb.MovePosition(newPosition);
        
    }


    // 控制 BOSS 移動
    private IEnumerator Movement()
    {
        int direction = Random.Range(0, 2) == 0 ? -1 : 1; // 隨機向上或向下移動
        float moveDuration = Random.Range(1f, 3f);         // 隨機移動持續時間
        float elapsed = 0f;

        movementDirection = Vector2.up * direction; // 設置垂直移動方向
        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        movementDirection = Vector2.zero; // 停止垂直移動
    }

    // 處理 BOSS 攻擊
    private void Attack()
    {
        Debug.Log("有想攻擊");
        // 攻擊冷卻計時
        if (currentFireCooldown <= 0f)
        {
            // 發射第一發子彈
            GameObject bullet1 = BOSSbulletPool.GetObject();
            bullet1.transform.position = firePoint1.position;
            bullet1.transform.rotation = firePoint1.rotation;

            //// 發射第二發子彈
            //GameObject bullet2 = BOSSbulletPool.GetObject();
            //bullet2.transform.position = firePoint2.position;
            //bullet2.transform.rotation = firePoint2.rotation;

            currentFireCooldown = fireRate; // 重置冷卻時間
        }
    }

    //判斷是否發生碰撞，扣除hp
    void OnTriggerEnter2D(Collider2D player)
    {
        // 檢查碰撞物體是否具有標籤 "Player"
        if (player.CompareTag("Bullet"))
        {
            BOSShp.GetComponent<Image>().fillAmount -= 0.01f;
            BOSShpAmount -= 1;
        }
    }

    public bool BOSSStatue() //是否要進入答題
    {
        if (BOSShpAmount<99)
        {
            return true;
        }
        return false;
    }
}
