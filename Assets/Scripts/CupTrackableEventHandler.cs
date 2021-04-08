using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTrackableEventHandler : DefaultTrackableEventHandler
{
    [SerializeField] TargetFoundText _targetFoundText;
    [SerializeField] bool _hideMesh;
    protected override void Start()
    {
        base.Start();

        _targetFoundText.gameObject.SetActive(false);
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        if (_hideMesh)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

        _targetFoundText.gameObject.SetActive(true);
    }

    protected override void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        var meshRendererComponents = GetComponentsInChildren<MeshRenderer>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;

        if (!_hideMesh)
        {
            foreach (var component in meshRendererComponents)
                component.enabled = false;
        }

        _targetFoundText.gameObject.SetActive(false);
    }
}
