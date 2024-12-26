using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks; // ���F�ϥ�await


public class QuestionManager : MonoBehaviour
{
    public GameObject quizPanel; // �u����������
    public Button option1Button; // ���s�ﶵ 1
    public Button option2Button; // ���s�ﶵ 2
    public Button option3Button; // ���s�ﶵ 3
    public Button option4Button; // ���s�ﶵ 4
    public GameObject correct;
    public GameObject wrong;
    [SerializeField] private BOSSControl bossControl; // �ޥ� BOSS �欰�}���A�קKBOSS�b���îɧ줣��

    private bool quizTriggered = false;

    void Start()
    {
        // ���üu��
        quizPanel.SetActive(false);
        correct.SetActive(false);
        wrong.SetActive(false);

        // �j�w���s�ƥ�
        option1Button.onClick.AddListener(() => HandleAnswer(false));
        option2Button.onClick.AddListener(() => HandleAnswer(false));
        option3Button.onClick.AddListener(() => HandleAnswer(false));
        option4Button.onClick.AddListener(() => HandleAnswer(true));
    }

    void Update()
    {
        // �ˬd BOSS ��q�O�_�C��@�b�A�ýT�O�uĲ�o�@��
        if (bossControl.BOSSStatue(50) && !quizTriggered)
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

    async void HandleAnswer(bool isCorrect)
    {
        // �P�_���׬O�_���T�]�i�X�i��h�޿�^
        if (isCorrect)
        {
            Debug.Log("���T���סI");
            correct.SetActive(true);
            await Task.Delay(1000); // ���� 1 ��]1000 �@��^,�u��ϥΦb�D�P�B(async)�����p�U
        }
        else
        {
            Debug.Log("���~���סI");
            wrong.SetActive(true);
            await Task.Delay(1000); // ���� 1 ��]1000 �@��^
        }

        // ���üu���ë�_�C��
        quizPanel.SetActive(false);
        correct.SetActive(false);
        wrong.SetActive(false);
        Time.timeScale = 1;
    }

}
