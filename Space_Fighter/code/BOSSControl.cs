using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSControl : MonoBehaviour
{
    public Transform firePoint1;        // �l�u�o�g�I 1
    public Transform firePoint2;        // �l�u�o�g�I 2
    public float BOSSMoveSpeed = 5f;    // ���ʳt��
    public float BOSSMoveCooldown = 2f; // ���ʧN�o�ɶ�
    public float fireRate = 1f;         // �l�u�o�g���j
    public GameObject bulletPrefab;     // �l�u�w�s����
    private float currentFireCooldown = 0f; // ��e�g���N�o
    private BOSSBulletPool BOSSbulletPool;         // �l�u��
    private Rigidbody2D rb;                // BOSS Rigidbody2D
    private CameraControl cameraPoint;       // �D��v��
    void Start()
    {
        BOSSbulletPool = FindObjectOfType<BOSSBulletPool>();
        rb = GetComponent<Rigidbody2D>();
        cameraPoint = FindObjectOfType<CameraControl>();
        StartCoroutine(BOSSBehavior()); // �Ұ� BOSS �欰�޿�
    }

    void Update()
    {

    }

    // BOSS �欰�޿�
    private IEnumerator BOSSBehavior()
    {
        while (true)
        {
            // ����
            yield return StartCoroutine(Movement());
            // ����
            Attack();
            // ���ݤU�@���欰
            yield return new WaitForSeconds(BOSSMoveCooldown);
        }
    }

    // ���� BOSS ����
    private IEnumerator Movement()
    {
        int direction = Random.Range(0, 2) == 0 ? -1 : 1; // �H���V�W�ΦV�U����
        float moveDuration = Random.Range(1f, 3f);         // �H�����ʫ���ɶ�
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

    // �B�z BOSS ����
    private void Attack()
    {
        // �����N�o�p��
        currentFireCooldown -= Time.deltaTime;
        if (currentFireCooldown <= 0f)
        {
            // �o�g�Ĥ@�o�l�u
            GameObject bullet1 = BOSSbulletPool.GetObject();
            bullet1.transform.position = firePoint1.position;
            bullet1.transform.rotation = firePoint1.rotation;

            // �o�g�ĤG�o�l�u
            GameObject bullet2 = BOSSbulletPool.GetObject();
            bullet2.transform.position = firePoint2.position;
            bullet2.transform.rotation = firePoint2.rotation;

            currentFireCooldown = fireRate; // ���m�N�o�ɶ�
        }
    }
}
