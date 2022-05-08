using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUiHandle : MonoBehaviour
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
        // Vì Scene đang chạy là Main Scene nên ta sẽ lấy Scene hiện tại bằng Method GetActiveScene()
        // GetActiveScene().name là lấy tên scene của cảnh hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Thoát game
    // Application.Quit dùng để tắt app
    public void Quit()
    {
        Application.Quit();
    }
}
