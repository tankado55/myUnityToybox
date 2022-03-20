using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(keyboardTracker))]
public class KeyboardTrackerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        keyboardTracker kt = target as keyboardTracker;

        EditorGUILayout.LabelField("Axes", EditorStyles.boldLabel);

       
        if (kt.axisKeys.Length == 0)
        {
            EditorGUILayout.HelpBox("No Axes defined in InputManager.", MessageType.Info);
        }
        else {
            SerializedProperty prop = serializedObject.FindProperty("axisKeys");
            for (int i = 0; i < kt.axisKeys.Length; i++) {
                EditorGUILayout.PropertyField(prop.GetArrayElementAtIndex(i), new GUIContent("Axis " + i));
            }
        }
        

        EditorGUILayout.LabelField("Buttons", EditorStyles.boldLabel);

        
        if (kt.buttonKeys.Length == 0) {
            EditorGUILayout.HelpBox("No Buttons defined in InputManager.", MessageType.Info);
        }
        else {
            SerializedProperty prop = serializedObject.FindProperty("buttonKeys");
            for (int i = 0; i < kt.buttonKeys.Length; i++)
            {
                kt.buttonKeys[i] = (KeyCode)EditorGUILayout.EnumPopup("Button " + i, kt.buttonKeys[i]);
            }
        }

        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }
}
