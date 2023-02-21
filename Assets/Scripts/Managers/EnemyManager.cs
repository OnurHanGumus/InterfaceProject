using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class EnemyManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        private int _health = 100;
        #endregion

        #region Serialized Variables

        #endregion

        #region Private Variables
        private PlayerData _data;
        #endregion
        #region Properties
        
        public int Health
        {
            get { return _health; }
            set { _health = value;
                if (_health <= 0)
                {
                    Debug.Log("Dead");
                    gameObject.SetActive(false);
                }
            }
        }

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            //_data = GetData();
        }
        //public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void OnPlay()
        {

        }
        private void OnResetLevel()
        {

        }
    }
}