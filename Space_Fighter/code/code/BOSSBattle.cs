using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSBattle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BOSS;
    public Transform BOSSIn;
    private bool bossActivated = false; // �O�_�w�Ұ� BOSS
    private CameraControl cameraPoint;       // �D��v��
    public GameObject BOSShp;          // BOSS ��q���
    private Rigidbody2D rb;                // BOSS Rigidbody2D

    void Start()
    {
        BOSS.SetActive(false);
        BOSShp.SetActive(false);
        cameraPoint = FindObjectOfType<CameraControl>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rightX = cameraPoint.GetRightEdgePosition();
        if (BOSSIn.position.x <= rightX.x && !bossActivated)
        {
            bossActivated = true;
            BOSS.SetActive(true);
            BOSShp.SetActive(true);
        }
        if (bossActivated) // ��BOSS���t����(�w�b�e���W)
        {
            Vector3 position = BOSS.transform.position;
            position.x += cameraPoint.moveSpeed * Time.deltaTime;
            rb.MovePosition(position);
        }
    }
}
