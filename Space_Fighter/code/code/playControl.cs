using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI; // �ޤJ UI �\��
using UnityEngine.SceneManagement;
using Unity.VisualScripting; // �ޤJ�����޲z�\��

public class PlayControl : MonoBehaviour
{
    public GameObject bulletPrefab;  // �l�u��Prefab
    public Transform firePoint;      // �l�u�o�g����m
    public float fireRate = 0.2f;    // �l�u���o�g���j
    public float moveSpeed = 10f;    // ���ʳt��
    private float fireCooldown = 0f; // �O���l�u���N�o�ɶ�
    private Rigidbody2D rb;          // ���⪺ Rigidbody2D
    private bullletPool bullletPool;

    private CameraControl cameraPoint; //�ɤJ���Y�첾�p��
    private EnemyPool enemyPool;
    public GameObject[] hearts; // �s�� Heart �Ϯת��}�C
    private int currentHP;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ��l�� cameraPoint
        cameraPoint = FindObjectOfType<CameraControl>();
        // �����H��,���I���O�إ߫غc�l
        bullletPool = FindObjectOfType<bullletPool>();
        enemyPool = FindObjectOfType<EnemyPool>();
        currentHP = hearts.Length; // �]�w��l�ͩR��
    }

    private void Update()
    {
        HandleMovement(); // ���ʻP��ɭ���
        HandleShooting(); // �g��
    }

    private void HandleMovement()
    {
        // �����V��J (�����M������V)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // �p�Ⲿ�ʤ�V�P�s��m
        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        Vector2 newPosition = rb.position + direction * moveSpeed * 3;

        if (cameraPoint != null)
        {
            newPosition = cameraPoint.ComputeCamera(newPosition);
        }

        // ��s�����m
        rb.MovePosition(newPosition);
    }

    private void HandleShooting()
    {
        // ��֧N�o�ɶ�
        fireCooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && fireCooldown <= 0f)
        {
            fireCooldown = fireRate; // ���m�N�o�ɶ�
            Shoot();
        }
    }

    private void Shoot()
    {
        // �ͦ��l�u
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletPrefab = bullletPool.GetObject(); // �q�������X�l�u
        bulletPrefab.transform.position = firePoint.position;
        bulletPrefab.transform.rotation = firePoint.rotation;
        //bulletPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0); //�|�Ĭ��bulletControl�������ʳ]�w

    }
    //�P�_�O�_�o�͸I���A����hp
    void OnTriggerEnter2D(Collider2D enemy)
    {
        // �ˬd�I������O�_�㦳���� "Player"
        if (enemy.CompareTag("Enemy") )
        {
            enemyPool.ReturnObject(enemy.gameObject);
            currentHP -= 1; // ��֥ͩR��

            // ���ù������߫��Ϯס]�q�̫�@�Ӷ}�l�^
            if (currentHP >= 0 && currentHP < hearts.Length)
            {
                hearts[currentHP].SetActive(false);
            }

            // �p�G�ͩR���k�s
            if (currentHP <= 0)
            {
            }
        }
    }

}
