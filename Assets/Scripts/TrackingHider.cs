using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingHider : MonoBehaviour
{
    [SerializeField] bool _hideOnTrackingFound;
    [SerializeField] TargetTrackableEventHandler[] _trackableEventHandlers;
    List<TargetTrackableEventHandler> _trackingTargets = new List<TargetTrackableEventHandler>();

    private void OnEnable()
    {
        foreach (var trackableEventHandler in _trackableEventHandlers)
        {
            trackableEventHandler.TrackingFound += OnTrackingFound;
            trackableEventHandler.TrackingLost += OnTrackingLost;
        }
    }

    private void OnTrackingLost(TargetTrackableEventHandler trackableEventHandler)
    {
        if (_trackingTargets.Contains(trackableEventHandler))
        {
            _trackingTargets.Remove(trackableEventHandler);
        }

        if (_hideOnTrackingFound)
        {
            if (_trackingTargets.Count == 0)
            {
                gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTrackingFound(TargetTrackableEventHandler trackableEventHandler)
    {
        if (!_trackingTargets.Contains(trackableEventHandler))
        {
            _trackingTargets.Add(trackableEventHandler);
        }

        if (_hideOnTrackingFound)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
