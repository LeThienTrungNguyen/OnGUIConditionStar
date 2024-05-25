using UnityEditor;
using UnityEngine;

public static class ConditionCloner
{
    public static Condition CloneCondition(Condition original)
    {
        if (original == null)
        {
            return null;
        }

        var clone = Object.Instantiate(original);
        clone.name = "Clone of " + original.name;
        return clone;
    }

    public static void DestroyClone(Condition clone)
    {
        if (clone != null && clone.name.StartsWith("Clone of "))
        {
            Object.DestroyImmediate(clone, true);
        }
    }
}