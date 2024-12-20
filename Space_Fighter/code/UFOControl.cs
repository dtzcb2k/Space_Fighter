using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOControl : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyPool enemyPool;
    void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.01f, 0, 0,Space.World);
        //�]���O�ϥ�translate�ҥH�i�H�ϥΥ@�ɮy�жi���V�W������
        if (transform.position.x <-13)
        {
            //Destroy(gameObject);
            enemyPool.ReturnObject(gameObject);
        }
        

    }
    // ��Ĳ�o���}�l�ɽե�
    void OnTriggerEnter2D(Collider2D enemy)
    {
        // �ˬd�I������O�_�㦳���� "Player"
        if (enemy.CompareTag("Player") || enemy.CompareTag("Bullet"))
        {
            //Destroy(gameObject);
            enemyPool.ReturnObject(gameObject);
        }
    }
}
