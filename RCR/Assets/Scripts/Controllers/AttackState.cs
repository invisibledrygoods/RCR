using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class AttackState : CircuitComponent
{
    public List<CircuitComponent> timeout;

    public float durationInSeconds;
    public GameObject hitbox;

    public string costSource;
    public float costAmount;

    float timeoutInSeconds;
    Transform module;

    public void Awake()
    {
        module = transform.GetModuleRoot();
    }

    public void Update()
    {
        timeoutInSeconds -= Time.deltaTime;

        if (timeoutInSeconds < 0)
        {
            Spark(timeout);
        }
    }

    public void OnEnable()
    {
        if (hitbox != null)
        {
            hitbox.SetActive(true);
            timeoutInSeconds = durationInSeconds;
        }

        module.Require<HasPoints>().Deal(costSource, costAmount);
    }

    public void OnDisable()
    {
        if (hitbox != null)
        {
            hitbox.SetActive(false);
        }
    }

    public void OnDrawGizmos()
    {
        DrawWires();

        if (hitbox != null)
        {
            GizmoTurtle turtle = new GizmoTurtle(transform.position);
            GizmoFont font = new RobotLetters(turtle, 0.4f);

            turtle.PenUp().RotateRight(90).Forward(0.12f).RotateLeft(90).Forward(0.15f);
            font.Write(hitbox.name);
        }
    }
}
