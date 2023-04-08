using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D spawnCollider;
    [field: SerializeField] private GameSettings _gameSettings;
    public static BlockSpawnController Instance;
    public static int SpawnZoneObjectCount;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }
    private void Start() {
        SpawnZoneObjectCount = 0;
    }
    // Start is called before the first frame update
    public GameObject SpawnBlock()
    {
        if(Physics2D.OverlapBox(spawnCollider.transform.position,spawnCollider.transform.localScale,360f,LayerMask.GetMask("Block")));
        // get RandomBlock with Chance
        GameObject _temp = _gameSettings.spawningObjectsList[Random.Range(0, _gameSettings.spawningObjectsList.Length)];
        Vector3 _pos = RandomPointInBounds(spawnCollider.bounds, _temp.GetComponent<BoxCollider2D>().bounds);
        
        GameObject _newblock = Instantiate(_temp, _pos, Quaternion.identity);
        return _newblock;

        // get Energy ?!

    }
    private static Vector3 RandomPointInBounds(Bounds bounds, Bounds newObject)
    {

        return new Vector3(
            Random.Range(bounds.min.x + newObject.max.x, bounds.max.x - newObject.max.x),
            Random.Range(bounds.min.y + newObject.max.y, bounds.max.y - newObject.max.y),
            0
        );
    }
    
    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

}
