using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject UFOPrefab;
    public GameObject Alien2Prefab;
    float span = 1.0f;
    float delta = 0;
    private EnemyPool enemyPool;
    private CameraControl cameraPoint; //導入鏡頭位移計算

    void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();

        // 初始化 cameraPoint
        cameraPoint = FindObjectOfType<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);//使的機器間的FPS不會影響到遊戲
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;//重置時間
            //GameObject go = Instantiate(Alien2Prefab) as GameObject;
            GameObject enemyPrefab = enemyPool.GetObject();
            int py = Random.Range(-4,4);
            Vector2 rightX = cameraPoint.GetRightEdgePosition();
            enemyPrefab.transform.position = new Vector3(rightX.x, py, 0);
            
        }
    }
}
