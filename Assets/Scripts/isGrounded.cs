using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Block")) && !other.CompareTag("Respawn"))
        {
            Debug.Log("TRIGGER");
            // BlockSpawnController.Instance.SpawnNewBlock();
            Destroy(this);
        }
    }
}
