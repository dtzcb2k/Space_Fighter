using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI���n�ɤJ�o��

public class BOSSControl : MonoBehaviour
{
    public GameObject BOSShp;
    public int BOSShpAmount=100;
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
    private Vector2 movementDirection; // �Ω�s�x���ʤ�V
    void Start()
    {
        BOSSbulletPool = FindObjectOfType<BOSSBulletPool>();
        rb = GetComponent<Rigidbody2D>();
        cameraPoint = FindObjectOfType<CameraControl>();
        StartCoroutine(BOSSBehavior()); // �Ұ� BOSS �欰�޿�
    }

    void Update()
    {
        currentFireCooldown -= Time.deltaTime;
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

    void FixedUpdate()
    {
        // �p��s��m
        Vector2 horizontalMovement = Vector2.right * cameraPoint.moveSpeed * Time.fixedDeltaTime;
        Vector2 newPosition = rb.position + movementDirection * BOSSMoveSpeed * Time.fixedDeltaTime + horizontalMovement;

        // ����ʽd��]�p�G�ݭn�^
        newPosition = cameraPoint.ComputeCamera(newPosition);

        // ��s Rigidbody2D ����m
        rb.MovePosition(newPosition);
        
    }


    // ���� BOSS ����
    private IEnumerator Movement()
    {
        int direction = Random.Range(0, 2) == 0 ? -1 : 1; // �H���V�W�ΦV�U����
        float moveDuration = Random.Range(1f, 3f);         // �H�����ʫ���ɶ�
        float elapsed = 0f;

        movementDirection = Vector2.up * direction; // �]�m�������ʤ�V
        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        movementDirection = Vector2.zero; // ���������
    }

    // �B�z BOSS ����
    private void Attack()
    {
        Debug.Log("���Q����");
        // �����N�o�p��
        if (currentFireCooldown <= 0f)
        {
            // �o�g�Ĥ@�o�l�u
            GameObject bullet1 = BOSSbulletPool.GetObject();
            bullet1.transform.position = firePoint1.position;
            bullet1.transform.rotation = firePoint1.rotation;

            //// �o�g�ĤG�o�l�u
            //GameObject bullet2 = BOSSbulletPool.GetObject();
            //bullet2.transform.position = firePoint2.position;
            //bullet2.transform.rotation = firePoint2.rotation;

            currentFireCooldown = fireRate; // ���m�N�o�ɶ�
        }
    }

    //�P�_�O�_�o�͸I���A����hp
    void OnTriggerEnter2D(Collider2D player)
    {
        // �ˬd�I������O�_�㦳���� "Player"
        if (player.CompareTag("Bullet"))
        {
            BOSShp.GetComponent<Image>().fillAmount -= 0.01f;
            BOSShpAmount -= 1;
        }
    }

    public bool BOSSStatue() //�O�_�n�i�J���D
    {
        if (BOSShpAmount<99)
        {
            return true;
        }
        return false;
    }
}
