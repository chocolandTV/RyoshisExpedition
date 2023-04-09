using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Vector2 PlayerDirection {get;set;}
    public float PlayerDirectionY{get;set;}
    public bool isSpeedup {get;set;}
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
        if(GameManager.Instance.currentBlock != null && PlayerDirection != Vector2.zero)
            GameManager.Instance.currentBlock.GetComponent<Rigidbody2D>().MovePosition(PlayerDirection + new Vector2(GameManager.Instance.currentBlock.transform.position.x, GameManager.Instance.currentBlock.transform.position.y));
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
