using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        other.collider.TryGetComponent(out IDamageReceiver damageReceiver);
        damageReceiver?.TouchTrap();
    }
}
