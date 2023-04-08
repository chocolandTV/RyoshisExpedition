using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D spawnCollider;
    [field: SerializeField] private GameSettings _gameSettings;
    public static BlockSpawnController Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
    }
    // Start is called before the first frame update
    public GameObject SpawnBlock()
    {
        // get RandomBlock with Chance
        GameObject _newblock =Instantiate(_gameSettings.spawningObjectsList[Random.Range(0,_gameSettings.spawningObjectsList.Length)],
        RandomPointInBounds(spawnCollider.bounds), Quaternion.identity);
        return _newblock;
        
        // get Energy ?!
       
    }
    private static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

}
