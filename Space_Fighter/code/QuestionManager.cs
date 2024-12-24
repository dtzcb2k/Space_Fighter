using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{
    public GameObject quizPanel; // �u����������
    public Button option1Button; // ���s�ﶵ 1
    public Button option2Button; // ���s�ﶵ 2
    public Button option3Button; // ���s�ﶵ 3
    public Button option4Button; // ���s�ﶵ 4
    private BOSSControl bossControl; // �ޥ� BOSS �欰�}��

    private bool quizTriggered = false;

    void Start()
    {
        bossControl = FindObjectOfType<BOSSControl>(); // ���������� BOSSControl
        // ���üu��
        quizPanel.SetActive(false);

        // �j�w���s�ƥ�
        option1Button.onClick.AddListener(() => HandleAnswer(true));
        option2Button.onClick.AddListener(() => HandleAnswer(false));
        option3Button.onClick.AddListener(() => HandleAnswer(false));
        option4Button.onClick.AddListener(() => HandleAnswer(false));
    }

    void Update()
    {
        // �ˬd BOSS ��q�O�_�C��@�b�A�ýT�O�uĲ�o�@��
        if (bossControl.BOSSStatue() && !quizTriggered)
        {
            quizTriggered = true;
            TriggerQuiz();
        }
    }

    void TriggerQuiz()
    {
        // �Ȱ��C��
        Time.timeScale = 0;

        // ��ܼu��
        quizPanel.SetActive(true);
    }

    void HandleAnswer(bool isCorrect)
    {
        // �P�_���׬O�_���T�]�i�X�i��h�޿�^
        if (isCorrect)
        {
            Debug.Log("���T���סI");
        }
        else
        {
            Debug.Log("���~���סI");
        }

        // ���üu���ë�_�C��
        quizPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
