using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 2f;
    public Transform cameraPoint;    // 鏡頭位置
    private float cameraHalfHeight;  // 攝影機範圍高度的一半
    private float cameraHalfWidth;   // 攝影機範圍寬度的一半
    private Camera mainCamera;       // 主攝影機

    public Vector2 ComputeCamera( Vector2 newPosition )
    {

        // 根據攝影機位置動態計算邊界
        Vector2 cameraPosition = cameraPoint.position;
        float minX = cameraPosition.x - cameraHalfWidth;
        float maxX = cameraPosition.x + cameraHalfWidth;
        float minY = cameraPosition.y - cameraHalfHeight;
        float maxY = cameraPosition.y + cameraHalfHeight;

        // 限制新位置在攝影機範圍內
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        return newPosition;
    }

    void Start()
    {
        mainCamera = Camera.main;

        // 計算攝影機範圍
        cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // 計算新的位置
        Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        // 更新相機位置
        transform.position = newPosition;
    }
}
