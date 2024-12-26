using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hpControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] hearts; // �s��ͩR�ȹϮ�
    private int maxHP;
    private int currentHP;
    void Start()
    {
        maxHP = hearts.Length; // �]�m�̤j�ͩR��
        currentHP = maxHP;
    }
    public void TakeDamage()
    {
        if (currentHP > 0)
        {
            currentHP--;
            hearts[currentHP].SetActive(false); // ���ù������߫��Ϯ�
        }
        // Update is called once per frame
        if (currentHP <= 0)
        {
            Debug.Log("���a���`");
            // ���a���`�޿�
            string Game_Over = "Game_Over";
            SceneManager.LoadScene(Game_Over);
        }
    }    
    void Update()
    {
        
    }
}
