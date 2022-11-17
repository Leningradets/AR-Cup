using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BottleSpiner : MonoBehaviour
{
    public event UnityAction SpinStopped;

    [SerializeField] float _minTorque;
    [SerializeField] float _maxTorque;

    [SerializeField] float _minAngularVelocity;

    private Rigidbody _rigidbody;
    private bool _isSpinning;
    private bool _enabled = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isSpinning)
        {
            if (_rigidbody.angularVelocity.magnitude < _minAngularVelocity)
            {
                _rigidbody.angularVelocity = Vector3.zero;
                _isSpinning = false;

                SpinStopped?.Invoke();
                _enabled = false;
            }
        }

        Debug.Log(_rigidbody.angularVelocity);
    }

    private void OnMouseUp()
    {
        if (!_isSpinning & _enabled)
        {
            Spin();
        }
    }

    private void Spin()
    {
        _rigidbody.angularVelocity = Vector3.up * Random.Range(_minTorque, _maxTorque);
        _isSpinning = true;
    }

    public void Enable()
    {
        _enabled = true;
    }
}
