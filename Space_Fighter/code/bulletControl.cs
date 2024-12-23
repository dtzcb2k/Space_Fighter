using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 0.03f;
    private CameraControl cameraPoint; //�ɤJ���Y�첾�p��
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
        transform.Translate(bulletSpeed, 0, 0,Space.World);
        OutOfRange();
    }
    void OnTriggerEnter2D(Collider2D Bullet)
    {
        if (gameObject.CompareTag("Bullet")) //player�g�X���l�u
        {
            if (Bullet.CompareTag("Enemy") || Bullet.CompareTag("BOSS"))
            {
                bullletPool.ReturnObject(gameObject); // �N�l�u�k�٨����
            }
        }
        else if (gameObject.CompareTag("BOSS")){ //BOSS�o�g���l�u
            if (Bullet.CompareTag("Player"))
            {
                bullletPool.ReturnObject(gameObject); // �N�l�u�k�٨����
            }
        }
        
    }
    void OutOfRange()
    {
        Vector2 limiteXY = cameraPoint.ComputeCamera(transform.position);
        if (transform.position.x > limiteXY.x || transform.position.x < limiteXY.x)
        {
            bullletPool.ReturnObject(gameObject); // �N�l�u�k�٨����
        }
    }
}
