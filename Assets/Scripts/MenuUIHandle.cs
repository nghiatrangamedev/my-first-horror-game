using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import thư viện SceneManagement sử dụng các method liên quan đến Scene
using UnityEngine.SceneManagement;

public class MenuUIHandle : MonoBehaviour
{
    // Tạo ra các Methods sẽ được gọi khi người chơi click vào các button trên UI
    // Chuyển đến Main Scene
    // SceneManage.LoadScene dùng để chuyển cảnh trong Unity
    public void GoToMain()
    {
        SceneManager.LoadScene("Main");
    }

    // Chuyển đến Tutorial Scene
    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // Thoát game
    // Application.Quit dùng để tắt app
    public void Quit()
    {
        Application.Quit();
    }
}
