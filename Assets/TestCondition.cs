using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestCondition : MonoBehaviour
{
    public Condition condition;

    private void OnValidate()
    {
        if (condition != null && condition.name == "Clone of " + condition.GetType().Name)
        {
            return;
        }
        if (condition != null)
        {
            condition = condition.Clone();
            condition.name = "Clone of " + condition.GetType().Name;
        }
    }

    private void OnDestroy()
    {
        if (condition != null && condition.name.StartsWith("Clone of "))
        {
            DestroyImmediate(condition, true);
        }
    }
}
