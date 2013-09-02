using UnityEngine;
using System.Collections;
using Require;
using Shouldly;

public class ChecksIfPointsOverThresholdTest : TestBehaviour
{
    ChecksIfPointsOverThreshold it;
    MockCircuitComponent yes;
    MockCircuitComponent no;
    HasPoints points;

    public override void Spec()
    {
        Given("it checks if 'test' points are over a threshold of 5")
            .And("its yes and no edges have receivers")
            .And("it has 10 'test' points")
            .When("it is enabled")
            .Then("its yes receiver should be enabled")
            .And("its no receiver should be disabled");
        
        Given("it checks if 'test' points are over a threshold of 5")
            .And("its yes and no edges have receivers")
            .And("it has 3 'test' points")
            .When("it is enabled")
            .Then("its no receiver should be enabled")
            .And("its yes receiver should be disabled");

        Given("it checks if 'test' points are over a threshold of 5")
            .And("its yes and no edges have receivers")
            .And("it has 5 'test' points")
            .When("it is enabled")
            .Then("its yes receiver should be enabled")
            .And("its no receiver should be disabled");
    }

    public void ItChecksIf__PointsAreOverAThresholdOf__(string type, float threshold)
    {
        it = transform.Require<ChecksIfPointsOverThreshold>();
        it.threshold = threshold;
        it.type = type;
        it.enabled = false;
    }

    public void ItsYesAndNoEdgesHaveReceivers()
    {
        yes = new GameObject().transform.Require<MockCircuitComponent>();
        no = new GameObject().transform.Require<MockCircuitComponent>();

        it.yes.Add(yes);
        it.no.Add(no);

        yes.enabled = false;
        no.enabled = false;
    }

    public void ItHas____Points(float amount, string type)
    {
        points = transform.Require<HasPoints>();
        points.Set(type, amount);
    }

    public void ItIsEnabled()
    {
        it.enabled = true;
    }

    public void ItsNoReceiverShouldBeEnabled()
    {
        no.enabled.ShouldBe(true);
    }

    public void ItsNoReceiverShouldBeDisabled()
    {
        no.enabled.ShouldBe(false);
    }
    
    public void ItsYesReceiverShouldBeEnabled()
    {
        yes.enabled.ShouldBe(true);
    }

    public void ItsYesReceiverShouldBeDisabled()
    {
        yes.enabled.ShouldBe(false);
    }
}
