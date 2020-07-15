using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject _enemyPrefabs;
    public GameObject[] powerUp;

    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(EnemyDownRoutine());
       StartCoroutine(PowerDownRoutine());
    }

    public void StartSpawnDownRoutine()
    {
        StartCoroutine(EnemyDownRoutine());
        StartCoroutine(PowerDownRoutine());
    }

    IEnumerator EnemyDownRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            
            Instantiate(_enemyPrefabs, new Vector3(Random.Range(-9f, 9f), 6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(7.0f);
        }
    }

    IEnumerator PowerDownRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            Instantiate(powerUp[Random.Range(0, 3)], new Vector3(Random.Range(-9f, 9f), 6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
