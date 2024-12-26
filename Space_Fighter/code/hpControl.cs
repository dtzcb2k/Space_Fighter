using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hpControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] hearts; // 存放生命值圖案
    private int maxHP;
    private int currentHP;
    void Start()
    {
        maxHP = hearts.Length; // 設置最大生命值
        currentHP = maxHP;
    }
    public void TakeDamage()
    {
        if (currentHP > 0)
        {
            currentHP--;
            hearts[currentHP].SetActive(false); // 隱藏對應的心型圖案
        }
        // Update is called once per frame
        if (currentHP <= 0)
        {
            Debug.Log("玩家死亡");
            // 玩家死亡邏輯
            string Game_Over = "Game_Over";
            SceneManager.LoadScene(Game_Over);
        }
    }    
    void Update()
    {
        
    }
}
