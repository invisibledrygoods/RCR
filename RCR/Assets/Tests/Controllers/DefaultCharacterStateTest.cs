using UnityEngine;
using System.Collections.Generic;
using Require;
using Shouldly;

public class DefaultCharacterStateTest : TestBehaviour
{
    Vector3 startingPosition;
    DefaultCharacterState it;
    MockUsesButtonInput buttons;

    public override void Spec()
    {
        Given("it knows where it started")
            .And("the joystick is held to the right")
            .When("it is in a default state")
            .ThenWithin("10 frames", "it should have moved to the right");

        Given("its input is mocked")
            .And("it is in a default state")
            .And("its A edge is wired to a receiver")
            .When("the 'A' button is released")
            .ThenWithin("10 frames", "the receiver should be enabled");
    }

    public void ItKnowsWhereItStarted()
    {
        startingPosition = transform.position;
    }

    public void TheJoystickIsHeldToTheRight()
    {
        transform.Require<MockUsesAxisInput>().Set("Horizontal", 1.0f);
    }

    public void ItsInputIsMocked()
    {
        buttons = transform.Require<MockUsesButtonInput>();
    }

    public void ItsAEdgeIsWiredToAReceiver()
    {
        MockCircuitReceiver receiver = transform.Require<MockCircuitReceiver>();
        it.A = new List<CircuitComponent>();
        it.A.Add(receiver);
        receiver.enabled = false;
    }

    public void ItIsInADefaultState()
    {
        transform.Require<ModuleRoot>();
        it = transform.Require<DefaultCharacterState>();
    }

    public void The__ButtonIsReleased(string button)
    {
        buttons.Release(button);
    }

    public void ItShouldHaveMovedToTheRight()
    {
        transform.position.x.ShouldBeGreaterThan(startingPosition.x);
    }

    public void TheReceiverShouldBeEnabled()
    {
        transform.Require<MockCircuitReceiver>().enabled.ShouldBe(true);
    }
}
