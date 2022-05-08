using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUIHandle : MonoBehaviour
{
    // Hiển thị con trỏ chuột trở lại
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Tạo ra các Methods sẽ được gọi khi người chơi click vào các button trên UI
    // Chuyển đến Main Scene
    // SceneManage.LoadScene dùng để chuyển cảnh trong Unity
    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    // Thoát game
    // Application.Quit dùng để tắt app
    public void Quit()
    {
        Application.Quit();
    }
}
