using UnityEngine;
using UnityEngine.Pool;

public class PlayControl : MonoBehaviour
{
    public GameObject bulletPrefab;  // 子彈的Prefab
    public Transform firePoint;      // 子彈發射的位置
    public float fireRate = 0.2f;    // 子彈的發射間隔
    public float moveSpeed = 10f;    // 移動速度

    private float fireCooldown = 0f; // 記錄子彈的冷卻時間
    private Rigidbody2D rb;          // 角色的 Rigidbody2D
    private bullletPool bullletPool;

    CameraControl cameraPoint; //導入鏡頭位移計算

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 初始化 cameraPoint
        cameraPoint = FindObjectOfType<CameraControl>();
        // 獲取對象池,有點像是建立建構子
        bullletPool = FindObjectOfType<bullletPool>(); 
    }

    private void Update()
    {
        HandleMovement(); // 移動與邊界限制
        HandleShooting(); // 射擊
    }

    private void HandleMovement()
    {
        // 獲取方向輸入 (水平和垂直方向)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 計算移動方向與新位置
        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        Vector2 newPosition = rb.position + direction * moveSpeed * 3;

        if (cameraPoint != null)
        {
            newPosition = cameraPoint.ComputeCamera(newPosition);
        }

        // 更新角色位置
        rb.MovePosition(newPosition);
    }

    private void HandleShooting()
    {
        // 減少冷卻時間
        fireCooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && fireCooldown <= 0f)
        {
            fireCooldown = fireRate; // 重置冷卻時間
            Shoot();
        }
    }

    private void Shoot()
    {
        // 生成子彈
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletPrefab = bullletPool.GetObject(); // 從池中取出子彈
        bulletPrefab.transform.position = firePoint.position;
        bulletPrefab.transform.rotation = firePoint.rotation;
        //bulletPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0); //會衝突到bulletControl中的移動設定

    }
}
