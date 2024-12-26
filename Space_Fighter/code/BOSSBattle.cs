using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSSBattle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BOSS;
    public Transform BOSSIn;
    private bool bossActivated = false; // �O�_�w�Ұ� BOSS
    private bool bossLife = true; // BOSS�٬��۶�?
    private CameraControl cameraPoint;       // �D��v��
    public GameObject BOSShp;          // BOSS ��q���
    [SerializeField] private BOSSControl bossControl; // �ޥ� BOSS �欰�}���A�קKBOSS�b���îɧ줣��

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
        // �ˬd BOSS ��q�O�_�k�s�A�ýT�O�uĲ�o�@��
        if (bossControl.BOSSStatue(0) && bossLife)
        {
            string Game_Clear = "Game_Clear";
            SceneManager.LoadScene(Game_Clear);
        }
    }
}
