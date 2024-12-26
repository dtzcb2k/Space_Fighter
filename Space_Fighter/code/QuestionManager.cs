using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks; // 為了使用await


public class QuestionManager : MonoBehaviour
{
    public GameObject quizPanel; // 彈窗的父物件
    public Button option1Button; // 按鈕選項 1
    public Button option2Button; // 按鈕選項 2
    public Button option3Button; // 按鈕選項 3
    public Button option4Button; // 按鈕選項 4
    public GameObject correct;
    public GameObject wrong;
    [SerializeField] private BOSSControl bossControl; // 引用 BOSS 行為腳本，避免BOSS在隱藏時抓不到

    private bool quizTriggered = false;

    void Start()
    {
        // 隱藏彈窗
        quizPanel.SetActive(false);
        correct.SetActive(false);
        wrong.SetActive(false);

        // 綁定按鈕事件
        option1Button.onClick.AddListener(() => HandleAnswer(false));
        option2Button.onClick.AddListener(() => HandleAnswer(false));
        option3Button.onClick.AddListener(() => HandleAnswer(false));
        option4Button.onClick.AddListener(() => HandleAnswer(true));
    }

    void Update()
    {
        // 檢查 BOSS 血量是否低於一半，並確保只觸發一次
        if (bossControl.BOSSStatue(50) && !quizTriggered)
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

    async void HandleAnswer(bool isCorrect)
    {
        // 判斷答案是否正確（可擴展更多邏輯）
        if (isCorrect)
        {
            Debug.Log("正確答案！");
            correct.SetActive(true);
            await Task.Delay(1000); // 等待 1 秒（1000 毫秒）,只能使用在非同步(async)的情況下
        }
        else
        {
            Debug.Log("錯誤答案！");
            wrong.SetActive(true);
            await Task.Delay(1000); // 等待 1 秒（1000 毫秒）
        }

        // 隱藏彈窗並恢復遊戲
        quizPanel.SetActive(false);
        correct.SetActive(false);
        wrong.SetActive(false);
        Time.timeScale = 1;
    }

}
