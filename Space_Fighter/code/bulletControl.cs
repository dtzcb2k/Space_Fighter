using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    float bulletSpeed = 0.03f;
    CameraControl cameraPoint; //�ɤJ���Y�첾�p��
    private bullletPool bullletPool;

    void Start()
    {
        // ��l�� cameraPoint
        cameraPoint = FindObjectOfType<CameraControl>();
        // �����H��,���I���O�إ߫غc�l
        bullletPool = FindObjectOfType<bullletPool>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletSpeed, 0, 0);
        Vector2 limiteXY = cameraPoint.ComputeCamera(transform.position);
        if (transform.position.x > limiteXY.x || transform.position.x < limiteXY.x)
        {
            bullletPool.ReturnObject(gameObject); // �N�l�u�k�٨����
        }
    }
    void OnTriggerEnter2D(Collider2D Bullet)
    {
        // �ˬd�I������O�_�㦳���� "Player"
        if (Bullet.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            bullletPool.ReturnObject(gameObject); // �N�l�u�k�٨����
        }
    }
}
