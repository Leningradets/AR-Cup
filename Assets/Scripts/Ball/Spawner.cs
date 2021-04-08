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

    private Thrower _thrower;
    private List<ThrowableObject> _throwableObjects = new List<ThrowableObject>();

    private void Awake()
    {
        _thrower = GetComponent<Thrower>();
    }

    private void OnEnable()
    {
        _thrower.Throwed += OnThrowableObjectThrowed;
    }

    private void OnDisable()
    {
        _thrower.Throwed -= OnThrowableObjectThrowed;
    }

    private void Start()
    {
        StartCoroutine(SpawnThrowableObject());
    }

IEnumerator SpawnThrowableObject()
    {
        yield return new WaitForSeconds(_timeBeforeSpawn);

        var throwableObject = Instantiate(_throwableObjectTemplate, transform.position, transform.rotation, transform);
        throwableObject.GetComponent<Rigidbody>().isKinematic = true;
        _throwableObjects.Add(throwableObject);

        ObjectSpawned?.Invoke(throwableObject); 
    }
    public void OnThrowableObjectThrowed(ThrowableObject throwableObject)
    {
        StartCoroutine(SpawnThrowableObject());
        throwableObject.transform.parent = _cylinderTarget.transform;

        _throwsViewer.UpdateValue();
    }
}
