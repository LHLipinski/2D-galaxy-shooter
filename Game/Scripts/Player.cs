using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShoot = false;
    public bool canSuperSpeed = false;
    public bool ShieldActive = false;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _ExplosionPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;


    [SerializeField]
    private float _fireRate = 0.25f;
    
    private float _canFire = 0.0f;

    //fireRate é 0.25f
    //canFire -- has the amount of time brtween firing passed?
    //Time.time


    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _superSpeed = 1.5f;
    [SerializeField]
    public int dead = 3;
    
    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (canSuperSpeed == true)
        {
            transform.Translate(Vector3.right * _speed * _superSpeed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * _superSpeed * verticalInput * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }
           
               

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);

        }
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);

        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }
    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            if (canTripleShoot == true)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(0.59f, 0, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(-0.59f, 0, 0), Quaternion.identity);


            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

            }
            _canFire = Time.time + _fireRate;
        }
    }


    void Start()
    {
        //current pos = new position
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();   
        }
    }
public void TripleShotPowerupOn()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());


    }
public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        canTripleShoot = false;


    }
    public void SpeedPowerupOn()
    {
        canSuperSpeed = true;
        StartCoroutine(SpeedPowerupDownRoutine());

    }
    public IEnumerator SpeedPowerupDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canSuperSpeed = false;

    }
    public void ShieldPowerupOn()
    {
        ShieldActive = true;
        _shieldGameObject.SetActive(true);
        
    }
    public void LostLife()
    {
        if (ShieldActive == true)
        {
            ShieldActive = false;
            _shieldGameObject.SetActive(false);
            return;
        }
       
       
       

            dead = dead - 1;
       
       
       if (dead < 0)
       {
            Instantiate(_ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

       }
        
    }



}
