using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemsText;

    private PlayerController playerControllerScript;
    private SpawnManager spawnManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GemsUpdate();
    }

    void GemsUpdate()
    {
        // Hiển thị số gems người chơi đã thu thập được lên UI
        gemsText.text = "Gems: " + playerControllerScript.gemsHaveCollected + "/8";
        // Nếu người chơi thu thập đủ số gems yêu cầu thì sẽ thông báo rằng người chơi đã chiến thắng
        if (playerControllerScript.gemsHaveCollected == spawnManagerScript.gemLength)
        {
            SceneManager.LoadScene("Win Scene");
        }
    }
}
