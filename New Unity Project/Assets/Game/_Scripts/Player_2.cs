using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{
    public bool canTripleShot = false;
    public bool canSpeedPower = false;
    public bool isShieldPower = false;
    public float _speed = 3.0f;
    public int lives = 3;

    public GameObject _laserPrefab;
    public GameObject _tripleShotPrefab;

    public GameObject _shieldsObject;
    public GameObject _explostionPrefab;

    private UIManager _uiManger;
    private GameManager _gameManager;
    private Spawn_Manager _spawn_Manager;

    public AudioClip _laserAudioClip;
    public AudioSource _audioSource;
    void Start()
    {
         _uiManger = GameObject.Find("Canvas").GetComponent<UIManager>();
         if(_uiManger != null)
        {
            _uiManger.UpdateLives(lives);
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _spawn_Manager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();

        if (_spawn_Manager != null)
        {
            _spawn_Manager.StartSpawnDownRoutine();
        }

        _audioSource.clip = _laserAudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    

    private void Shoot()
    {
        if (canTripleShot)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }
        _audioSource.Play();
    }
    private void Mover()
    {
        float horizontalInput = Input.GetAxis("Horizontal");  
        float verticalInput = Input.GetAxis("Vertical");
 
        if (canSpeedPower)
        {
            transform.Translate(Vector3.right * _speed * 1.5f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * 1.5f *  verticalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }

        if (transform.position.y > 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, 0);
        }
        else if (transform.position.y < -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }

        if (transform.position.x > 8.5f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.5f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }
    }
    public void Damge()
    {
        if (isShieldPower)
        {
            isShieldPower = false;
            _shieldsObject.SetActive(false);
            return;
        }
        lives--;
        _uiManger.UpdateLives(lives);
        if (lives < 1)
        {
            Destroy(gameObject);
            Instantiate(_explostionPrefab, transform.position, Quaternion.identity);
            _gameManager.gameOver = true;
            _uiManger._gameOverText.gameObject.SetActive(true);
            //_uiManger.ShowTitleGamePlay();
        }
    }
    public void CanShieldsPowerOn()
    {
        isShieldPower = true;
        _shieldsObject.SetActive(true);
        StartCoroutine(ShiledsPowerDownRoutine());

    }
    public IEnumerator ShiledsPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isShieldPower = false;
        _shieldsObject.SetActive(false);
    }
    public void CanSpeedPowerOn()
    {
        canSpeedPower = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    public IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeedPower = false;
    }
    public void CanTripleShotOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }
}
