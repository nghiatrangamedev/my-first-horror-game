using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Khai báo biến player để lấy component Tranform từ GameObject Player
    public Transform player;
    // Khai báo biến mouseX để nhận input "Mouse X" từ Unity Input Manager
    private float mouseX;
    // Khai báo biến mouseY để nhận input "Mouse Y" từ Unity Input Manager
    private float mouseY;
    // Khai báo biến sensivity để đại diện cho tốc độ chuột, tốc độ chuột càng cao camera xoay càng nhanh
    private float sensitivity = 100.0f;
    // Khai báo biến rotationX để đại diện cho góc xoay lên xuống của người chơi.
    private float rotationX = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Không cho con trỏ chuột hiện thị trên màn hình Game Play
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Gán Input Manager "Mouse X" và "Mouse Y" cho 2 biến "mouseX", "mouseY"
        // Nhân với tốc độ chuột và Time.deltaTime để đảm game không chạy quá nhanh
        // Nếu không nhân với Time.deltaTime thì tốc độ quay của camera sẽ rất nhanh
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime ;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Giảm giá trị của X dựa vào giá trị của y. Nếu tăng giá trị của X theo giá trị của Y thì sẽ bị lộn.
        // VD: Đưa chuột lên trên người chơi sẽ hướng xuống dưới
        rotationX -= mouseY;
        // Đảm bảo người chơi chỉ xoay lên/ xuống được tối đa là 90 độ.
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        // Thay đổi góc cho camera
        transform.localRotation = Quaternion.Euler(new Vector3(rotationX, 0, 0));

        // Quay trục y để quay người sang trái hoặc phải. Vì xoay cả người nên thứ phải xoay sẽ là GameObject player
        player.transform.Rotate(Vector3.up * mouseX);

    }
}
