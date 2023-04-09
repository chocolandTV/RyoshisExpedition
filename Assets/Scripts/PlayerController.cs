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
    public void Rotate()
    {
        GameManager.Instance.currentBlock.transform.Rotate(0, 0, 90);
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
        if(GameManager.Instance.currentBlock != null){
            Vector2 pos = new Vector2(PlayerDirectionX, PlayerDirectionY+ Gravity);
            Vector2 objPos = new Vector2(GameManager.Instance.currentBlock.transform.position.x, GameManager.Instance.currentBlock.transform.position.y);
            GameManager.Instance.currentBlock.GetComponent<Rigidbody2D>().MovePosition(pos + objPos* Time.fixedDeltaTime);
            
        
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
