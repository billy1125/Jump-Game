using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 別忘了要追加 UI 必要程式
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public GameObject Player;
    Vector3 playerPos; // 角色的位置
    public GameObject hpGauge;     //置放血環的公開變數
    int Life = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeArrow", 0, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0)
            // 遊戲重新開始
            SceneManager.LoadScene("GameScene");

        playerPos = Player.transform.position; // 更新角色的位置        
    }

    void MakeArrow()
    {
        float px = Random.Range(-3.0f, 4.0f);
        float py = playerPos.y + 6;
        Instantiate(ArrowPrefab, new Vector3(px, py, 0), Quaternion.identity);
    }

    // 公開（Public）的方法（DecreaseHp），每執行一次，Fill Amount的數值就減少0.1
    public void DecreaseHp()
    {
        Life -= 1;
        hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
