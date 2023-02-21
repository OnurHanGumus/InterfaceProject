using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Managers;
using UnityEngine;
using Data.UnityObject;
using Data.ValueObject;
using System;
using System.Collections;

namespace Controllers
{
    public class BulletMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables



        #endregion

        #region Private Variables
        private Rigidbody _rig;
        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }
        private void Init()
        {
            _rig = GetComponent<Rigidbody>();
        }


        private void OnEnable()
        {
            _rig.AddRelativeForce(Vector3.forward * 5, ForceMode.Impulse);
            StartCoroutine(Disable());
        }
        private void OnDisable()
        {
            _rig.velocity = Vector3.zero;
        }

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
        }
    }
}