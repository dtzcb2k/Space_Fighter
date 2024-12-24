using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{
    public GameObject quizPanel; // 彈窗的父物件
    public Button option1Button; // 按鈕選項 1
    public Button option2Button; // 按鈕選項 2
    public Button option3Button; // 按鈕選項 3
    public Button option4Button; // 按鈕選項 4
    private BOSSControl bossControl; // 引用 BOSS 行為腳本

    private bool quizTriggered = false;

    void Start()
    {
        bossControl = FindObjectOfType<BOSSControl>(); // 找到場景中的 BOSSControl
        // 隱藏彈窗
        quizPanel.SetActive(false);

        // 綁定按鈕事件
        option1Button.onClick.AddListener(() => HandleAnswer(true));
        option2Button.onClick.AddListener(() => HandleAnswer(false));
        option3Button.onClick.AddListener(() => HandleAnswer(false));
        option4Button.onClick.AddListener(() => HandleAnswer(false));
    }

    void Update()
    {
        // 檢查 BOSS 血量是否低於一半，並確保只觸發一次
        if (bossControl.BOSSStatue() && !quizTriggered)
        {
            quizTriggered = true;
            TriggerQuiz();
        }
    }

    void TriggerQuiz()
    {
        // 暫停遊戲
        Time.timeScale = 0;

        // 顯示彈窗
        quizPanel.SetActive(true);
    }

    void HandleAnswer(bool isCorrect)
    {
        // 判斷答案是否正確（可擴展更多邏輯）
        if (isCorrect)
        {
            Debug.Log("正確答案！");
        }
        else
        {
            Debug.Log("錯誤答案！");
        }

        // 隱藏彈窗並恢復遊戲
        quizPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
