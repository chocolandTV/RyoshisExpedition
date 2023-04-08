using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject currentBlock {get;set;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBlock != null)
        {
            if(currentBlock.GetComponent<Rigidbody2D>().velocity.y < 0.05f)
            {
                currentBlock = BlockSpawnController.Instance.SpawnBlock();
            }
        }else{
            currentBlock = BlockSpawnController.Instance.SpawnBlock();
        }
    }
}
