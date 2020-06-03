
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] PowerUps;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }






    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {

            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }

    }
    IEnumerator PowerUpSpawnRoutine()
    {
        while (true)
        {
            int randonPowerUp = Random.Range(0, 3);
            Instantiate(PowerUps[randonPowerUp], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }

    }

}
    








