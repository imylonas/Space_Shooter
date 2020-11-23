using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShoot : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    private float _yDestroyBound = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > _yDestroyBound)
        {
            Destroy(this.gameObject);
        }
    }
}
