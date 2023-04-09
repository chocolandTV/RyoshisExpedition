using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
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
    
    // Update is called once per frame
    // private void Update() {
        
        
    // }
    
    public void OnPause()
    {
        
    }
}
