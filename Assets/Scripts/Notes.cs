using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public List<Vector3> NotePosition  = new List<Vector3>();
    private void OnDrawGizmos() {
        if(NotePosition != null)
        {
            for (int i = 0; i < NotePosition.Count; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(NotePosition[i],0.1f);
            }
        }
    }
}
