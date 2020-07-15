using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.4f;
    [SerializeField]
    private int powerId;

    public AudioClip _clip;
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with: " + other.name);

        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                if(powerId == 0)
                {
                    player.CanTripleShotPowerOn();
                }
                else if ( powerId == 1)
                {
                    player.CanSpeedPowerOn();
                }
                else if ( powerId == 2)
                {
                    player.CanShieldPowerOn();
                }
                
            }

            Destroy(gameObject);
        }

        else if(other.tag == "Player_2")
        {
            Player_2 player_2 = other.GetComponent<Player_2>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);
            if (player_2 != null)
            {
                if (powerId == 0)
                {
                    player_2.CanTripleShotOn();
                }
                else if (powerId == 1)
                {
                    player_2.CanSpeedPowerOn();
                }
                else if ( powerId == 2)
                {
                    player_2.CanShieldsPowerOn();
                }
            }

            Destroy(gameObject);
        }
    }
}
