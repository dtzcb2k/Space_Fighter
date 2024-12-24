using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSBulletPool : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab; // �n�ͦ����w�s��
    public int poolSize = 10; // �w�]���j�p
    private Queue<GameObject> BOSSpool;

    void Start()
    {
        Debug.Log("BOSSBulletPool");
        BOSSpool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            BOSSpool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        Debug.Log("���o�l�u");
        if (BOSSpool.Count > 0)
        {
            GameObject obj = BOSSpool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab); // �Y�������󤣨��h�ͦ��s����
            return obj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        BOSSpool.Enqueue(obj);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
