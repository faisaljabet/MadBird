using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FlyCat flyCat = collision.collider.GetComponent<FlyCat>(); 
        if(flyCat != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Rat rat = collision.collider.GetComponent<Rat>();
        if(rat != null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < -0.5 || collision.contacts[0].normal.x < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
