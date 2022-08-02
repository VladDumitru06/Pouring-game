using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectPool))]
[CanEditMultipleObjects]
public class ObjectPoolEditor : Editor
{
    SerializedProperty Objects;
    bool showItems = false;
    void OnEnable()
    {
        
    }
    public override void OnInspectorGUI()
    {
        ObjectPool _TempOP = (ObjectPool)target;
        if (_TempOP.objects == null)
        {
            _TempOP.objects = new Dictionary<GameObject, int>();
        }
        int size = Mathf.Max(0, EditorGUILayout.IntField("Size", _TempOP.objects.Count));//_TempOP.objects.Count
        while (size > _TempOP.objects.Count)
        {
            GameObject _tempGO = new GameObject();
            _TempOP.objects.Add(_tempGO, 0);
            DestroyImmediate(_tempGO);
        }
        while (size < _TempOP.objects.Count)
        {
            _TempOP.objects.Remove(_TempOP.objects.ElementAt(_TempOP.objects.Count-1).Key);
        }
        showItems = EditorGUILayout.BeginFoldoutHeaderGroup(showItems, new GUIContent());

        if (showItems)
        {
            EditorGUI.indentLevel++;
            foreach (KeyValuePair<GameObject, int> keyValuePairs in _TempOP.objects)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField("Object", keyValuePairs.Key, typeof(GameObject), false);
                EditorGUILayout.IntField("Amount", keyValuePairs.Value);
                EditorGUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        base.OnInspectorGUI();
    }
    public void OnGUI()
    {
    }

}
