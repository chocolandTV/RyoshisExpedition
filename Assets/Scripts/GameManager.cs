using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject currentBlock {get;set;}
    // public LayerMask ground;
    public bool isGameOver {get;set;}
    public static GameManager Instance;
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
    void Start()
    {
        
    }
    private bool isGrounded()
    {
        return (currentBlock.GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Block")));
    
    }
    // Update is called once per frame
    void Update()
    {
        if(currentBlock != null)
        {
            if(isGrounded())
            {
                currentBlock = BlockSpawnController.Instance.SpawnBlock();
            }
        }else{
            currentBlock = BlockSpawnController.Instance.SpawnBlock();
        }
    }
}
