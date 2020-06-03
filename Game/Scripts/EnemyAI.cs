using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _Enemy_explosionPrefab;
    
    [SerializeField]
    private float _speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(-5.48f, 6.15f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -6.11)
        {
            float randomx = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomx, 6.0f, 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("Collided with: " + other.name);

            if (other.tag == "Player")
            {
                Player player = other.GetComponent<Player>();
            if (player != null)
            {


                player.LostLife();
            }
            Instantiate(_Enemy_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
            }
        if (other.tag == "Laser")
        {
            Laser laser = other.GetComponent<Laser>();
            if(laser != null)
            {
                laser.Damage();

            }
            Instantiate(_Enemy_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            

        }
        
        
        
        Instantiate(_Enemy_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }
}
