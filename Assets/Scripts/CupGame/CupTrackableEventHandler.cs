using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTrackableEventHandler : TargetTrackableEventHandler
{
    MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        _renderer.enabled = false;
    }
}
