using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RemoveColliders : MonoBehaviour
{
    [MenuItem("Tools/Remover Colliders de Hijos")]
    static void RemoveAllColliders()
    {
        if (Selection.activeGameObject == null)
        {
            Debug.LogWarning("No seleccionaste ningún objeto.");
            return;
        }

        GameObject parent = Selection.activeGameObject;
        Collider[] colliders = parent.GetComponentsInChildren<Collider>();

        int count = 0;
        foreach (var col in colliders)
        {
            if (col.gameObject != parent) // No borres el del padre si lo tiene
            {
                DestroyImmediate(col);
                count++;
            }
        }

        Debug.Log($"Se eliminaron {count} colliders de los hijos de {parent.name}");
    }
}
