using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class Thrower : MonoBehaviour
{
    public event UnityAction<ThrowableObject> Throwed;

    [SerializeField] private float _force;
    [SerializeField] private float _objectLifeTime;

    private Spawner _spawner;

    private Vector2 _startMousePosition;

    private List<ThrowableObject> _objects =  new List<ThrowableObject>();

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _spawner.ObjectSpawned += OnObjectSpawned;
    }

    private void OnDestroy()
    {
        _spawner.ObjectSpawned -= OnObjectSpawned;
    }

    private void Throw(ThrowableObject throwableObject)
    {
        Vector3 throwDirection = GetThrowDirection();
        var rigidbody = throwableObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddForce(throwDirection * _force);
        Throwed?.Invoke(throwableObject);
    }

    private Vector3 GetThrowDirection()
    {
        var throwDirection = new Vector3();

        var mousePosition = Input.mousePosition;
        var mouseDelta = _startMousePosition - new Vector2(mousePosition.x, mousePosition.y);

        throwDirection = - transform.right * mouseDelta.x - transform.up * mouseDelta.y - transform.forward * mouseDelta.y;

        return throwDirection;
    }

    public void OnObjectSpawned(ThrowableObject throwableObject)
    {
        throwableObject.Clicked += OnObjectClicked;
        _objects.Add(throwableObject);
    }

    public void OnObjectClicked(ThrowableObject throwableObject)
    {
        _startMousePosition = Input.mousePosition;
        throwableObject.Clicked -= OnObjectClicked;
        throwableObject.Released += OnMouseReleased;
    }

    public void OnMouseReleased(ThrowableObject throwableObject)
    {
        Throw(throwableObject);
        throwableObject.DestroyWithDelay(_objectLifeTime);
        throwableObject.Released -= OnMouseReleased;
    }
}
