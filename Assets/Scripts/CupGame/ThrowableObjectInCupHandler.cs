using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThrowableObjectInCupHandler : MonoBehaviour
{
    public event UnityAction ThrowableObjectInCup;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ThrowableObject _throwableObject))
        {
            ThrowableObjectInCup?.Invoke();
        }

        Destroy(other.gameObject);
    }
}
