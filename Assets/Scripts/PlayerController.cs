using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Khai báo biến để tham chiếu đến Game Object Game Over
    [SerializeField] private GameObject gameOver;

    // Khai báo biến controller để nhận component CharacterController. Thứ giúp người chơi di chuyển
    [SerializeField] CharacterController controller;
    // Khai báo 2 biến "horizontalInput" và "verticalInput" để chứa 2 Input "Vertical" và "horizontal" từ Unity
    private float horizontalInput;
    private float verticalInput;

    private AudioSource playerAudioSource;
    public AudioClip collectedSound;
    // Khai báo biến speed đại diện cho tốc độ di chuyển của người chơi
    private float speed = 10.0f;
    // Khai báo biến để kiểm tra số gems người chơi thu thập được
    public float gemsHaveCollected = 0;
    // Update is called once per frame

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        // Gán giá trị cho 2 biến "horizontalInput" và "verticalInput" đại diện cho tốc độ di chuyển sang trái/ phải, đi thẳng/ lùi lại của người chơi
        // Time.delta để khiến cho tốc độ di chuyển ổn định, không quá nhanh hoặc quá chậm
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Khai báo một "move" đại diện cho hướng di chuyển của người chơi.
        // "Vector3.right * horizontalInput" di chuyển người chơi sang trái/ phải
        // "Vector3.forward * verticalInput" di chuyển người chơi tiến lên/ lùi xuống
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        // "controller.Move" là method để một game object
        controller.Move(move * speed * Time.deltaTime );
    }


    // Dùng method OnTriggerEnter để kiểm tra xem GameObject PLayer có va chạm với các GameObject khác hay không
    // Lý do không sử dụng OnColligeEnter vì Player không có RigidBody

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem liệu thứ va chạm với GameObject Player có phải GameObject Ghost hay không thông qua method CompareTag
        // Vì GameObject Ghost đã được gắn tag "Ghost" nên ta có thể so sánh được
        if (other.gameObject.CompareTag("Ghost"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            // Nếu GameObject Player va chạm với GameObject được gắn tag Ghost, thì sẽ Destroy GameObject có gắn tag  Ghost và GameObject Player
            Destroy(other.gameObject);
            Destroy(gameObject);
            // Hiển thị dòng chữ GameOver ra màn hình để nói với người chơi rằng trò chơi đã kết thúc
            // Hiển thị các button Play Again hoặc Quit để người chơi có thể chơi lại hoặc thoát game
            gameOver.SetActive(true);
            // Hiển thị lại con trỏ chuột
        }

        // Kiểm tra xem liệu GameObject PLayer có đang chạm vào GameObject Gem hay không
        // Nếu có thì sẽ Destroy GameObject Gem vì người chơi đang thu thập Gem
        // Kiểm tra va chạm giữa GameObject Game và GameObjec Player thông qua method so sánh tag là CompareTag
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            playerAudioSource.PlayOneShot(collectedSound, 1.0f);
            // Hiển thị cho người chơi biết họ đã thu thập được gem
            gemsHaveCollected++;
        }
    }
}
