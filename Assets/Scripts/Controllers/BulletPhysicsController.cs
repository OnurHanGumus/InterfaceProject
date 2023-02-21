using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysicsController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables
    [SerializeField] private int damage = 20;
    #endregion
    #region Private Variables


    #endregion
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageableObject))
        {
            damageableObject.GetDamage(damage);
        }
    }
}
