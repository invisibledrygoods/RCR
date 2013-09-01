using UnityEngine;
using System.Collections.Generic;
using Require;

public class MockUsesAxisInput : UsesAxisInput
{
    Dictionary<string, float> joystick = new Dictionary<string,float>();

    public void Set(string axisName, float value)
    {
        joystick[axisName] = value;
    }

    public override float Get(string axisName)
    {
        float value;
        joystick.TryGetValue(axisName, out value);
        return value;
    }
}
