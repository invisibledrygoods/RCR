using UnityEngine;
using System.Collections;
using Require;

public class DefaultCharacterState : CircuitComponent
{
    Transform module;
    FollowsTarget movement;

    void Awake()
    {
        module = transform.GetModuleRoot();
        movement = module.Require<FollowsTarget>();
    }

    void Update()
    {
        movement.target = module.position;
        Debug.Log(Input.GetAxis("Vertical"));

        if (Input.GetAxis("Vertical") > 0.1f)
        {
            movement.target += Vector3.forward;
        }
        
        if (Input.GetAxis("Vertical") < -0.1f)
        {
            movement.target -= Vector3.forward;
        }
        
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            movement.target += Vector3.right;
        }
        
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            movement.target -= Vector3.right;
        }
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
