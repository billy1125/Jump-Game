using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public GameObject Player;
    Vector3 playerPos; // 角色的位置

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeArrow", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Player.transform.position; // 更新角色的位置
    }

    void MakeArrow()
    {
        float px = Random.Range(-3.0f, 4.0f);
        float py = playerPos.y + 6;
        Instantiate(ArrowPrefab, new Vector3(px, py, 0), Quaternion.identity);
    }

}
