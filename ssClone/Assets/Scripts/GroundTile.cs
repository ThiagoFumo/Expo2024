using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.5f;
    public float laneWidth = 3f; // Ancho de cada carril


    private void Start()
    {
     groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();   
     SpawnObstacle();
     SpawnCoin();
    }

    private void OnTriggerExit(Collider other){
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }
    private void Update()
    {
        
    }

    public void SpawnObstacle(){
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random < tallObstacleChance){
            obstacleToSpawn = tallObstaclePrefab;
        }

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoin(){
        int carrilASpawnear = Random.Range(-1, 1);
        float lugarSpawn = carrilASpawnear * laneWidth;
        Vector3 spawnPoint = new Vector3(lugarSpawn, transform.position.y + 1, transform.position.z);
        GameObject tempo = Instantiate(coinPrefab, spawnPoint, Quaternion.identity, transform);                    //tempo.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        /*GameObject tmp = Instantiate(coinPrefab, transform);
        Vector3 tmpPosition = GetRandomPointInCollider(GetComponent<Collider>());
        tmp.transform.position = tmpPosition;*/  
    } 

            

    Vector3 GetRandomPointInCollider (Collider collider){
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if(point != collider.ClosestPoint(point)){
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }    
    
}
