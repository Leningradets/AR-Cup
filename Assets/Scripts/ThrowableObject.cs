using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ThrowableObject : MonoBehaviour
{
    public event UnityAction<ThrowableObject> Clicked;
    public event UnityAction<ThrowableObject> Released;
    public void DestroyWithDelay(float delay)
    {
        Destroy(gameObject, delay);
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(this);
    }

    private void OnMouseUp()
    {
        Released?.Invoke(this);
    }
}
