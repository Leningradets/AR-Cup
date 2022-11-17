using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class Spawner : MonoBehaviour
{
    public event UnityAction<ThrowableObject> ObjectSpawned;

    [SerializeField] private ThrowableObject _throwableObjectTemplate;
    [SerializeField] private float _timeBeforeSpawn;
    [SerializeField] private CylinderTargetBehaviour _cylinderTarget;
    [SerializeField] private ThrowsViewer _throwsViewer;
    [SerializeField] private TargetTrackableEventHandler _trackableEventHandler;

    private Thrower _thrower;
    private List<ThrowableObject> _throwableObjects = new List<ThrowableObject>();
    private ThrowableObject _currentThrowableObject;

    private void Awake()
    {
        _thrower = GetComponent<Thrower>();
    }

    private void OnEnable()
    {
        _thrower.Throwed += OnThrowableObjectThrowed;
        _trackableEventHandler.TrackingFound += OnTrackingFound;
    }

    private void OnTrackingFound(TargetTrackableEventHandler targetTrackableEventHandler)
    {
        if (!_currentThrowableObject)
        {
            SpawnThrowableObject();
        }
    }

    private void OnDisable()
    {
        _thrower.Throwed -= OnThrowableObjectThrowed;
    }

    IEnumerator SpawnThrowableObjectWithDelay()
    {
        yield return new WaitForSeconds(_timeBeforeSpawn);
        SpawnThrowableObject();
    }

    private void SpawnThrowableObject()
    {
        _currentThrowableObject = Instantiate(_throwableObjectTemplate, transform.position, transform.rotation, transform);
        _currentThrowableObject.GetComponent<Rigidbody>().isKinematic = true;
        _throwableObjects.Add(_currentThrowableObject);

        ObjectSpawned?.Invoke(_currentThrowableObject);
    }

    public void OnThrowableObjectThrowed(ThrowableObject throwableObject)
    {
        StartCoroutine(SpawnThrowableObjectWithDelay());
        throwableObject.transform.parent = _cylinderTarget.transform;

        _throwsViewer.UpdateValue();
    }
}
