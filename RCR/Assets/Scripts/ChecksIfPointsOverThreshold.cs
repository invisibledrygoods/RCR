using UnityEngine;
using System.Collections.Generic;
using Require;
using System;

public class ChecksIfPointsOverThreshold : CircuitComponent
{
    public float threshold;
    public string type;

    public List<CircuitComponent> yes = new List<CircuitComponent>();
    public List<CircuitComponent> no = new List<CircuitComponent>();

    Transform module;

    void Awake()
    {
        module = transform.GetModuleRoot();
    }

    void OnEnable()
    {
        HasPoints points = module.Require<HasPoints>();

        if (points.Has(type) && points.Get(type) >= threshold)
        {
            Spark(yes);
        }
        else
        {
            Spark(no);
        }
    }

    void OnDrawGizmos()
    {
        DrawWires();
    }
}
