using UnityEngine;
using System.Collections;
using Shouldly;
using Require;

public class FollowsTargetTest : TestBehaviour
{
    FollowsTarget it;

    public override void Spec()
    {
        Given("it follows a target 1 m to the left")
            .When("its speed is 1 m per second")
            .ThenWithin("1.1 second", "it should be at its target");

        Given("it follows a target 1 m to the left")
            .When("its speed is 0.5 m per second")
            .ThenWithin("2.1 second", "it should be at its target");

        Given("it follows a target 1 m to the left")
            .When("its speed is 0.5 m per second")
            .ThenWithin("1.9 second", "it should not be at its target");
    }

    public void ItFollowsATarget__MToTheLeft(float distance)
    {
        it = transform.Require<FollowsTarget>();
        it.target = transform.position + Vector3.left * distance;
    }

    public void ItsSpeedIs__MPerSecond(float speed)
    {
        it.speed = speed;
    }

    public void ItShouldBeAtItsTarget()
    {
        Vector3.Distance(it.target, it.transform.position).ShouldBe(0);
    }

    public void ItShouldNotBeAtItsTarget()
    {
        Vector3.Distance(it.target, it.transform.position).ShouldNotBe(0);
    }
}
