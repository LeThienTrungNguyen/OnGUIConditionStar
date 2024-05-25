using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Condition : ScriptableObject

{
    public float threshold1;
    public float threshold2;
    public float threshold3;

    public virtual float CheckThreshold(float currentThreshold)
    {
        return 0;
    }
    public Condition Clone()
    {
        return Instantiate(this);
    }
}
[CustomEditor(typeof(Condition),true)]
public class ConditionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This editor is for internal use only.", MessageType.Info);
    }
}
[CustomPropertyDrawer(typeof(Condition), true)]
public class ConditionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property, label, true);

        if (property.objectReferenceValue != null)
        {
            EditorGUI.indentLevel++;

            SerializedObject so = new SerializedObject(property.objectReferenceValue);

            var soType = property.objectReferenceValue.GetType();
            var fields = soType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var field in fields)
            {
                var prop = so.FindProperty(field.Name);
                if (prop != null)
                {
                    position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), prop, true);
                }
            }

            so.ApplyModifiedProperties();

            EditorGUI.indentLevel--;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUI.GetPropertyHeight(property, label, true);

        if (property.objectReferenceValue != null)
        {
            SerializedObject so = new SerializedObject(property.objectReferenceValue);
            var soType = property.objectReferenceValue.GetType();
            var fields = soType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var field in fields)
            {
                var prop = so.FindProperty(field.Name);
                if (prop != null)
                {
                    height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                }
            }
        }

        return height;
    }
}
