using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetTrackableEventHandler : DefaultTrackableEventHandler
{
    public event UnityAction<TargetTrackableEventHandler> TrackingFound;
    public event UnityAction<TargetTrackableEventHandler> TrackingLost;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        TrackingFound?.Invoke(this);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        TrackingLost?.Invoke(this);
    }
}
