using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.magenta;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.ViewRadius);

        Handles.color = Color.red;
        foreach( Transform visibleTarget in fow.VisibleTargets)
        {
        Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }
}
