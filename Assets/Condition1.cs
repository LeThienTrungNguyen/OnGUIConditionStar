using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "StarConditons/Condition1")]
public class Condition1 : Condition
{
    public override float CheckThreshold(float currentThressHold)
    {
        return 0;
    }
}
