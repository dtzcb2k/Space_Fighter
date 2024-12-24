using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSBulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 5f;
    private CameraControl cameraPoint; //�ɤJ���Y�첾�p��
    private BOSSBulletPool BOSSBulletPool;
    private Rigidbody2D rb;          // ���⪺ Rigidbody2D

    void Start()
    {
        // ��l�� cameraPoint
        cameraPoint = FindObjectOfType<CameraControl>();
        // �����H��,���I���O�إ߫غc�l
        BOSSBulletPool = FindObjectOfType<BOSSBulletPool>();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("BOSSBulletControl");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-bulletSpeed, 0); // �Y���O�@�ɮy��
        OutOfRange();
    }

    void OutOfRange()
    {
        Vector2 limiteXY = cameraPoint.ComputeCamera(transform.position);
        if (transform.position.x > limiteXY.x || transform.position.x < limiteXY.x)
        {
            BOSSBulletPool.ReturnObject(gameObject); // �N�l�u�k�٨����
        }
    }
}
