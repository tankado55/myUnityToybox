using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InputManager))] // quando unity vede un oggetto input manager nell'ispector sa che deve usare questa classe
public class InputManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {

        InputManager im = target as InputManager; // target e' la roba che dovrebbe disegnare
        EditorGUI.BeginChangeCheck();
        base.OnInspectorGUI();
        if (EditorGUI.EndChangeCheck()) { //se qualcuno ha modificato qualcosa dall'editor
            im.RefreshTracker();
        }
    }
}
