using UnityEngine;
using System.Collections;
using System;
using Require;
using Shouldly;

public class AttackStateTest : TestBehaviour
{
    AttackState it;

    public override void Spec()
    {
        Given("it has an attack state")
            .And("it has an attack hitbox")
            .And("its attack animation takes 0.2 seconds")
            .When("it enters the attack state")
            .ThenWithin("0.1 seconds", "its attack hitbox should be active")
            .AndWithin("0.1 seconds", "it should be enabled")
            .AndWithin("0.3 seconds", "its attack hitbox should be inactive")
            .AndWithin("0.3 seconds", "it should be disabled");
    }

    public void ItHasAnAttackState()
    {
        transform.Require<ModuleRoot>();
        it = transform.Require<AttackState>();
        it.enabled = false;
    }

    public void ItHasAnAttackHitbox()
    {
        it.hitbox = new GameObject();
        it.hitbox.SetActive(false);
    }

    public void ItsAttackAnimationTakes__Seconds(float durationInSeconds)
    {
        it.durationInSeconds = durationInSeconds;
    }

    public void ItEntersTheAttackState()
    {
        it.enabled = true;
    }

    public void ItsAttackHitboxShouldBeActive()
    {
        it.hitbox.activeSelf.ShouldBe(true);
    }

    public void ItsAttackHitboxShouldBeInactive()
    {
        it.hitbox.activeSelf.ShouldBe(false);
    }

    public void ItShouldBeEnabled()
    {
        it.enabled.ShouldBe(true);
    }

    public void ItShouldBeDisabled()
    {
        it.enabled.ShouldBe(false);
    }
}
