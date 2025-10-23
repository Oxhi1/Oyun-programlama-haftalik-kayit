using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject collectablePrefab; 
    public int spawnCount = 10;          
    public float spawnRange = 10f;       

    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                0.5f, 
                Random.Range(-spawnRange, spawnRange)
            );

            
            Instantiate(collectablePrefab, spawnPos, Quaternion.identity);
        }
    }
}
