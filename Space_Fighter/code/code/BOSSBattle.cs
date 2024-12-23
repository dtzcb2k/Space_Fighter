using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSBattle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BOSS;
    public Transform BOSSIn;
    private bool bossActivated = false; // 是否已啟動 BOSS
    private CameraControl cameraPoint;       // 主攝影機
    public GameObject BOSShp;          // BOSS 血量顯示
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
        if (bossActivated) // 讓BOSS等速移動(定在畫面上)
        {
            Vector3 position = BOSS.transform.position;
            position.x += cameraPoint.moveSpeed * Time.deltaTime;
            rb.MovePosition(position);
        }
    }
}
