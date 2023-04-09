using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public float PlayerDirectionX {get;set;}
    public float PlayerDirectionY{get;set;}
    public bool isSpeedup {get;set;}
    private float Gravity = -9.81f;
    [field:SerializeField] private GameSettings _gameSettings;
    public void Rotate()
    {
        BlockSpawnController.Instance.currentBlock.transform.Rotate(0, 0, 90);
    }
    private void Awake() {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Move()
    {
        if(BlockSpawnController.Instance.currentBlock != null){
            // Vector2 pos = new Vector2(PlayerDirectionX*Speed,BlockSpawnController.Instance.currentBlock.GetComponent<Rigidbody2D>().velocity.y);
            // Vector2 objPos = new Vector2(BlockSpawnController.Instance.currentBlock.transform.position.x, BlockSpawnController.Instance.currentBlock.transform.position.y);
            // BlockSpawnController.Instance.currentBlock.GetComponent<Rigidbody2D>().MovePosition((pos* Time.fixedDeltaTime) + objPos);
            BlockSpawnController.Instance.currentBlock.GetComponent<Rigidbody2D>().AddForce(transform.right *PlayerDirectionX * _gameSettings.ObjectSpeed);
            BlockSpawnController.Instance.currentBlock.GetComponent<Rigidbody2D>().AddForce(transform.up *-(PlayerDirectionY * _gameSettings.ObjectSpeed),ForceMode2D.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate() {
    
        Move();
    }
}
