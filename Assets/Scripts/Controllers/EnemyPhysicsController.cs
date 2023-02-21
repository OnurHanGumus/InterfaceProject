using Data.ValueObject;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class EnemyPhysicsController : MonoBehaviour, IDamageable
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private EnemyManager manager;
        #endregion
        #region Private Variables


        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {

        }

        public void GetDamage(int value)
        {
            manager.Health -= value;
        }
        public void OnPlay()
        {

        }
        public void OnLevelFailed()
        {

        }
        public void OnLevelSuccess()
        {

        }
        public void OnRestartLevel()
        {

        }
    }
}