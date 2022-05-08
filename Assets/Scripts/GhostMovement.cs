using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    // Tạo ra một biến để nhận tốc độ của Ghost
    [SerializeField] float speed = 10.0f;
    // Tạo ra một biến để nhận vị trí của Player
    private Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChasePlayer();
    }

    // Tạo 1 hàm khiến Ghost đuổi theo người chơi
    private void ChasePlayer()
    {
        // Ghost sẽ căn cứ vào vị trí hiện tại của người chơi để tìm ra khoảng cách và hướng đi hợp lý
        // Tạo ra 1 biến thuộc kiểu Vector đại diện cho hướng đi của ghost và khoảng cách giữa ghost và người chơi
        // Ta lấy vị trí hiện tại của người trừ đi vị trí hiện tại của ghost để tìm ra hướng và khoảng cách cần đi
        // Dùng normalized để đảm bảo Ghost không chạy quá nhanh
        Vector3 moveDirection = (playerPosition.position - transform.position).normalized;
        // Khiến cho Ghost nhìn vào người chơi
        transform.LookAt(playerPosition.position);
        // Khiến GameObject Ghost đuổi theo người chơi theo một hướng định sẵn. Không dùng AddFroce từ RigidBody vì sẽ xảy ra nhiều bug khi Ghost di chuyển
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

}
