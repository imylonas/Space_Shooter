using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    /* 0 : Triple Shoot
       1 : Speed Boost
       2 : Shields */
    [SerializeField]
    private int powerUpId;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if(powerUpId == 0)
                {
                    player.TripleShootPowerUpOn();
                }
                else if(powerUpId == 1)
                {
                    player.SpeedBoostOn();
                }
                else if(powerUpId == 2)
                {
                    //player.ShieldOn();
                }
            }
            
            Destroy(this.gameObject);
        }
    }

}
