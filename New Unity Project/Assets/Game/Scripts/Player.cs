using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool canTripleShot = false;
    public bool isSpeedBoostActive = false;
    public bool isShieldActive = false;
    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private GameObject _explositionPrefab;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldsObject;


    [SerializeField]
    private float _speed = 5.0f;
    private void Update()
    {
        Movement();
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
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.29f, 0), Quaternion.identity);
        }
        
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       

        if( isSpeedBoostActive)
        {
            transform.Translate(Vector3.right * horizontalInput * _speed * 1.5f * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * _speed * 1.5f * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        }


        if (transform.position.y < -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }
        if (transform.position.y > 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, 0);
        }


        if (transform.position.x < -9.2f)
        {
            transform.position = new Vector3(-9.2f, transform.position.y, 0);
        }
        if (transform.position.x > 9.1f)
        {
            transform.position = new Vector3(9.1f, transform.position.y, 0);
        }
    }
    //Dame Player 
    public void Damge()
    {

        if (isShieldActive)
        {
            isShieldActive = false;
            _shieldsObject.SetActive(false);
            return;
        }
        lives--;

        if ( lives < 1)
        {
            Destroy(gameObject);
            Instantiate(_explositionPrefab, transform.position, Quaternion.identity);
        }
    }
    //power Shield Active 
    public void CanShieldPowerOn()
    {
        isShieldActive = true;
        StartCoroutine(ShieldPowerDownRountine());
        _shieldsObject.SetActive(true);
        
    }
    public IEnumerator ShieldPowerDownRountine()
    {
        yield return new WaitForSeconds(5.0f);
        isShieldActive = false;
    }
    //power Speed Active
    public void CanSpeedPowerOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }
    public IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }
    //Power Triple shot
    public void CanTripleShotPowerOn()
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
                                                          