using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Time.timeScale = 0;
            Application.Quit(); //�������ε{��
            Debug.Log("���a���`");
            // ���a���`�޿�
        }
    }    
    void Update()
    {
        
    }
}
