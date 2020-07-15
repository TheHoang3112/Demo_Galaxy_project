using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject _enemyExplosionPrefab;
    private GameObject EnemyExplosionPrefab;
    public float _speed = 3f;
    private UIManager _uiManager;
    // Update is called once per frame
     void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 6f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            EnemyExplosionPrefab = Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(EnemyExplosionPrefab);
            _uiManager.UpdateScore();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if ( player != null)
            {
                player.Damge();
            }
        }
        else if ( other.tag == "Player_2")
        {
            Player_2 player_2 = other.GetComponent<Player_2>();

            if( player_2 != null)
            {
                player_2.Damge();
            }
        }
        Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
