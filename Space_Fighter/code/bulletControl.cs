using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 5f;
    private CameraControl cameraPoint; //�ɤJ���Y�첾�p��
    private bulletPool bulletPool;
    private Rigidbody2D rb;
    void Start()
    {
        // ��l�� cameraPoint
        cameraPoint = FindObjectOfType<CameraControl>();
        // �����H��,���I���O�إ߫غc�l
        bulletPool = FindObjectOfType<bulletPool>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(bulletSpeed, 0); // �Y���O�@�ɮy��
        OutOfRange();
    }
    void OnTriggerEnter2D(Collider2D Bullet)
    {
        if (Bullet.CompareTag("Enemy") || Bullet.CompareTag("BOSS"))
        {
            bulletPool.ReturnObject(gameObject); // �N�l�u�k�٨����
        }
    }
    void OutOfRange()
    {
        Vector2 limiteXY = cameraPoint.ComputeCamera(transform.position);
        if (transform.position.x > limiteXY.x || transform.position.x < limiteXY.x)
        {
            bulletPool.ReturnObject(gameObject); // �N�l�u�k�٨����
        }
    }
}
