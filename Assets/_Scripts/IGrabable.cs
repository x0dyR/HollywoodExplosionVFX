using UnityEngine;

public interface IGrabable
{
    Rigidbody Rigidbody { get; }

    Transform Transform { get; }

    void Grab(Vector3 dragPosition);

    void Release();
}
