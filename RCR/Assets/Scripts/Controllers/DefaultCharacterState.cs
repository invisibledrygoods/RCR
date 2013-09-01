using UnityEngine;
using System.Collections.Generic;
using Require;

public class DefaultCharacterState : CircuitComponent
{
    public List<CircuitComponent> A;
    public List<CircuitComponent> B;

    Transform module;
    FollowsTarget movement;
    UsesAxisInput axis;
    UsesButtonInput buttons;

    void Awake()
    {
        module = transform.GetModuleRoot();
        movement = module.Require<FollowsTarget>();
        axis = module.Require<UsesAxisInput>();
        buttons = module.Require<UsesButtonInput>();
    }

    void Update()
    {
        movement.target = module.position;

        if (axis.Get("Vertical") > 0.1f)
        {
            movement.target += Vector3.forward;
        }
        
        if (axis.Get("Vertical") < -0.1f)
        {
            movement.target -= Vector3.forward;
        }
        
        if (axis.Get("Horizontal") > 0.1f)
        {
            movement.target += Vector3.right;
        }
        
        if (axis.Get("Horizontal") < -0.1f)
        {
            movement.target -= Vector3.right;
        }

        if (buttons.Released("A"))
        {
            Spark(A);
        }

        if (buttons.Released("B"))
        {
            Spark(B);
        }
    }

    void OnDisable()
    {
        movement.target = module.position;
    }

    void OnDrawGizmos()
    {
        GizmoTurtle turtle = new GizmoTurtle(transform.position);

        turtle.PenUp().Forward(0.3f);
        turtle.PenDown().RotateLeft(90).Forward(0.1f).RotateLeft(90).Forward(0.2f)
            .RotateRight(90).Forward(0.2f).RotateLeft(90).Forward(0.2f).RotateLeft(90).Forward(0.2f)
            .RotateRight(90).Forward(0.2f).RotateLeft(90).Forward(0.2f).RotateLeft(90).Forward(0.2f)
            .RotateRight(90).Forward(0.2f).RotateLeft(90).Forward(0.2f).RotateLeft(90).Forward(0.2f)
            .RotateRight(90).Forward(0.2f).RotateLeft(90).Forward(0.1f);

        DrawWires();
    }
}
