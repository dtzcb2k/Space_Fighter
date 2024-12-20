using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 2f;
    public Transform cameraPoint;    // ���Y��m
    private float cameraHalfHeight;  // ��v���d�򰪫ת��@�b
    private float cameraHalfWidth;   // ��v���d��e�ת��@�b
    private Camera mainCamera;       // �D��v��

    public Vector2 ComputeCamera( Vector2 newPosition )
    {

        // �ھ���v����m�ʺA�p�����
        Vector2 cameraPosition = cameraPoint.position;
        float minX = cameraPosition.x - cameraHalfWidth;
        float maxX = cameraPosition.x + cameraHalfWidth;
        float minY = cameraPosition.y - cameraHalfHeight;
        float maxY = cameraPosition.y + cameraHalfHeight;

        // ����s��m�b��v���d��
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        return newPosition;
    }

    void Start()
    {
        mainCamera = Camera.main;

        // �p����v���d��
        cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // �p��s����m
        Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        // ��s�۾���m
        transform.position = newPosition;
    }
}
