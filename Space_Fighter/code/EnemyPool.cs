using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab; // �n�ͦ����w�s��
    public int poolSize = 20; // �w�]���j�p
    private Queue<GameObject> enemyPool;

    void Start()
    {
        enemyPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            enemyPool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (enemyPool.Count > 0)
        {
            GameObject obj = enemyPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(enemyPrefab); // �Y�������󤣨��h�ͦ��s����
            return obj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        enemyPool.Enqueue(obj);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
