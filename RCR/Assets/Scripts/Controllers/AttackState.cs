using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class AttackState : CircuitComponent
{
    public List<CircuitComponent> timeout;

    public float durationInSeconds;
    public GameObject hitbox;

    float timeoutInSeconds;

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
        if (hitbox != null)
        {
            GizmoTurtle turtle = new GizmoTurtle(transform.position);
            GizmoFont font = new RobotLetters(turtle, 0.4f);

            font.Write(hitbox.name);
        }

        DrawWires();
    }
}
