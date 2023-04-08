using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public List<Vector3> NotePosition  = new List<Vector3>();
    [field:SerializeField] public GameObject EnergyObject;
    private void Start() {
        foreach (Vector3 x in NotePosition)
        {
            GameObject _obj = Instantiate(EnergyObject, x, Quaternion.identity);
            _obj.gameObject.transform.parent = this.transform;
            _obj.transform.position = gameObject.transform.position + x;
        }
        Destroy(this);
    }
    private void OnDrawGizmos() {
        if(NotePosition != null)
        {
            for (int i = 0; i < NotePosition.Count; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(NotePosition[i] + transform.position,Vector3.one *1f);
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(NotePosition[i] + transform.position,0.1f);
            }
        }
    }
}
