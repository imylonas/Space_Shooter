using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;

    [SerializeField]
    private float speed = 5.0f;

    private float x_bound = 9.5f;

    private float y_bound = 4.2f;

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0,0.88f,0),Quaternion.identity);
        }

    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float VerticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        transform.Translate(Vector3.up * speed * VerticalInput * Time.deltaTime);

        if (transform.position.y > y_bound)
        {
            transform.position = new Vector3(transform.position.x, -y_bound + 0.2f, 0);
        }
        else if (transform.position.y < -y_bound)
        {
            transform.position = new Vector3(transform.position.x, -y_bound, 0);
        }
        else if (transform.position.x > x_bound)
        {
            transform.position = new Vector3(-x_bound, transform.position.y, 0);
        }
        else if (transform.position.x < -x_bound)
        {
            transform.position = new Vector3(x_bound, transform.position.y, 0);
        }
    }
}
