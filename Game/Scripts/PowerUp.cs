using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{ 
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID;//0 = triple shoot, 1 = speed, 2 = shield


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    
     
    
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {

                if (powerupID == 0)
                {
                    player.TripleShotPowerupOn();

                }
                else if (powerupID == 1)
                {
                    player.SpeedPowerupOn();

                }

                else if (powerupID == 2)
                {

                    player.ShieldPowerupOn();

                }
            }
            Destroy(this.gameObject);
           


        }



    }  

}
