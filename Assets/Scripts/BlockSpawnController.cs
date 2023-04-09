using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D spawnCollider;
    [field: SerializeField] private GameSettings _gameSettings;
    public static BlockSpawnController Instance;
    public static int SpawnZoneObjectCount;
    public GameObject currentBlock {get;set;}
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }
    private void Start()
    {
        SpawnZoneObjectCount = 0;
        SpawnNewBlock();
    }
    // Start is called before the first frame update
    public void SpawnNewBlock()
    {
        // if(currentBlock != null)
        // {
        //     if(isGrounded())
        //     {
        //         currentBlock = SpawnBlock();
        //     }
           
        // }else{
            currentBlock = SpawnBlock();
        // }
    }
    // private bool isGrounded()
    // {
    //     return (currentBlock.GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Block")));
    
    // }
    private GameObject SpawnBlock()
    {

        if (Physics2D.OverlapBoxAll(spawnCollider.transform.position, Vector2.one, 360f, LayerMask.GetMask("Block")).Length >= 3)
        {
            GameManager.Instance.isGameOver = true;
            Debug.Log("GAME OVER");
        }
        GameObject _obj = getRandomBlockItem();
        Vector3 _pos = RandomPointInBounds(spawnCollider.bounds, _obj.GetComponent<BoxCollider2D>().bounds);

        GameObject _newblock = Instantiate(_obj, _pos, Quaternion.identity);
        return _newblock;
    }
    private GameObject getRandomBlockItem()
    {
        GameObject _object = _gameSettings.spawningObjectsList[Random.Range(0, _gameSettings.spawningObjectsList.Length)];
        int randomChance = Random.Range(1,SumBlockChance());
        int counter =0;
        // 22 
        for (int i = 0; i < _gameSettings.blockChance.Length; i++)
        {
            if( randomChance < _gameSettings.blockChance[i] + counter){
                
                
                return _gameSettings.spawningObjectsList[i];}
            else
                counter +=_gameSettings.blockChance[i];
        }
        
        return _object;
    }
    private static Vector3 RandomPointInBounds(Bounds bounds, Bounds newObject)
    {

        return new Vector3(
            Random.Range(bounds.min.x + newObject.max.x, bounds.max.x - newObject.max.x),
            Random.Range(bounds.min.y + newObject.max.y, bounds.max.y - newObject.max.y),
            0
        );
    }
   
    private int SumBlockChance()
    {
        int sum = 0;
        foreach (int x in _gameSettings.blockChance)
        {
            sum += x;
        }
        return sum;
    }
    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

}
