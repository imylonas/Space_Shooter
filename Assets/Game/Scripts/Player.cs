using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShoot = false;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleLaserPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;

    private float _xBound = 9.5f;

    private float _yBound = 4.2f;

    // Start is called before the first frame update
    void Start()
    {
        // Starting position
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }

    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float VerticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);

        transform.Translate(Vector3.up * _speed * VerticalInput * Time.deltaTime);

        if (transform.position.y > _yBound)
        {
            transform.position = new Vector3(transform.position.x, -_yBound + 0.2f, 0);
        }
        else if (transform.position.y < -_yBound)
        {
            transform.position = new Vector3(transform.position.x, -_yBound, 0);
        }
        else if (transform.position.x > _xBound)
        {
            transform.position = new Vector3(-_xBound, transform.position.y, 0);
        }
        else if (transform.position.x < -_xBound)
        {
            transform.position = new Vector3(_xBound, transform.position.y, 0);
        }
    }

    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            if (canTripleShoot)
            {
                Instantiate(_tripleLaserPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }

            _canFire = Time.time + _fireRate;

        }

    }

    public void TripleShootPowerUpOn()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShootPowerDownRoutine());
    }

    public IEnumerator TripleShootPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        canTripleShoot = false;
    }

}
