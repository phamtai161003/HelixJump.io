using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    public float rotationSpeed;

    private void Update()
    {
    #if UNITY_EDITOR
        //PC
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            // Rotate around the Y axis (up vector) based on mouseX movement.
            transform.Rotate(Vector3.up, -mouseX * rotationSpeed * Time.deltaTime);
        }
    #elif UNITY_ANDROID
        //mobile
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            // Rotate around the Y axis (up vector) based on mouseX movement.
            transform.Rotate(Vector3.up, -mouseX * rotationSpeed * Time.deltaTime);
        }
        if (Input.touchCount > 0)
        {
            // Lấy thông tin về điểm chạm đầu tiên
            Touch touch = Input.GetTouch(0);

            // Xử lý điểm chạm di chuyển ngang
            if (touch.phase == TouchPhase.Moved)
            {
                // Lấy độ dịch chuyển ngang của điểm chạm và điều chỉnh nó
                float deltaX = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                // Xoay GameObject quanh trục Y
                transform.Rotate(Vector3.up, -deltaX);
            }
        }
    #endif
    }
}
