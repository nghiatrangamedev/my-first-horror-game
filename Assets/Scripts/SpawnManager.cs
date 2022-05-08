using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Tạo ra một GameObject để nhận Prefab Ghost
    [SerializeField] GameObject ghostPrefab;
    // Tạo ra một GameObject để nhận Prefab  Gem
    [SerializeField] GameObject gemPrefab;
    // Khởi tạo một biến đại diện cho vị trí z mà Ghost sẽ được tạo ra trong method RandomSpawn()
    private float zGhostPosSpawn = -22.0f;
    // Khởi tạo một biến đại diện cho vị trí y mà Ghost sẽ được tạo ra trong method RandomSpawn()
    private float yGhostPosSpawn = 3.0f;
    // Khởi tạo một biến đại diện cho vị trí x mà Ghost và Gem sẽ được tạo ra trong method RandomSpawn()
    private float xRangeSpawn = 22.0f;
    // Khởi tạo một biến đại diện cho vị trí x mà Gem sẽ được tạo ra trong method RandomSpawn()
    private float zGemRangeSpawn = 22.0f;
    // Khởi tạo một biến đại diện cho số lượng Gem người chơi cần thu thập
    public int gemLength = 8;
    // Khởi tạo một biến đại diện cho thời gian cần phăỉ đợi trước khi GameObject Ghost được tạo ra
    private float waitForSpawnGhost = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnGems(gemLength);
        // Tạo ra một GameObject Ghost sau 5s khi trò chơi bắt đầu
        // Sử dụng method Ienumerator bằng method StartCoroutine
        StartCoroutine(SpawnGhost(waitForSpawnGhost));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Tạo ra vị trí ngẫu nhiên của Ghost sau một khoảng thời gian sau khi trò chơi bắt đầu để người chơi có thời gian chuẩn bị
    // IEnumerator sẽ đợi 1 lúc rồi mới thực hiện các câu lệnh bên trong nó
    IEnumerator SpawnGhost(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        // Khởi tạo một biến nhận giá trị ngẫu nhiên nằm trong khoảng từ -xRangeSpawn đến xRangeSpawn
        float randomPosX = Random.Range(-xRangeSpawn, xRangeSpawn);
        // Khởi tạo vị trí của GameObject Ghost theo Vector3
        Vector3 ghostPos = new Vector3(randomPosX, yGhostPosSpawn, zGhostPosSpawn);
        // Tạo ra GameObject Ghost từ Prefab, đặt vị trí và góc cho nó 
        Instantiate(ghostPrefab, ghostPos, ghostPrefab.transform.rotation);
    }


    // Tạo ra số gems để người chơi thu thập
    private void SpawnGems(int gemLength)
    {
        for (int i = 0; i < gemLength; i++)
        {
            // Tạo ra vị trí ngẫu nhiên của Gem
            float randomPosX = Random.Range(-xRangeSpawn, xRangeSpawn);
            float randomPosZ = Random.Range(-zGemRangeSpawn, zGemRangeSpawn);
            Vector3 gemPos = new Vector3(randomPosX, 1.5f, randomPosZ);

            // Tạo ra 1 GameObject Gem từ Prefab Gem và gán ví trị và góc cho nó
            Instantiate(gemPrefab, gemPos, gemPrefab.transform.rotation);
        }
    }
}
