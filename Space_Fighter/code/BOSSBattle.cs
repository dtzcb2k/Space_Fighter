using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSSBattle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BOSS;
    public Transform BOSSIn;
    private bool bossActivated = false; // 是否已啟動 BOSS
    private bool bossLife = true; // BOSS還活著嗎?
    private CameraControl cameraPoint;       // 主攝影機
    public GameObject BOSShp;          // BOSS 血量顯示
    [SerializeField] private BOSSControl bossControl; // 引用 BOSS 行為腳本，避免BOSS在隱藏時抓不到

    void Start()
    {
        BOSS.SetActive(false);
        BOSShp.SetActive(false);
        cameraPoint = FindObjectOfType<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossActivated)
        {
            Vector2 rightX = cameraPoint.GetRightEdgePosition();
            if (BOSSIn.position.x <= rightX.x && !bossActivated)
            {
                bossActivated = true;
                BOSS.SetActive(true);
                BOSShp.SetActive(true);
            }
        }
        Game_Clear();
    }

    public void Game_Clear()
    {
        // 檢查 BOSS 血量是否歸零，並確保只觸發一次
        if (bossControl.BOSSStatue(0) && bossLife)
        {
            string Game_Clear = "Game_Clear";
            SceneManager.LoadScene(Game_Clear);
        }
    }
}
