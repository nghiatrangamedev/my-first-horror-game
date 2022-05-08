using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import thư viện SceneManagement để sử dụng các method liên quan đến Scene
using UnityEngine.SceneManagement;

public class TutorialUIHandle : MonoBehaviour
{
    // Tạo ra các Methods sẽ được gọi khi người chơi click vào các button trên UI
    // Chuyển vê Menu Scene
    public void BackToTheMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
