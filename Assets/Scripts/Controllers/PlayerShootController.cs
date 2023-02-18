using Data.ValueObject;
using Managers;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerShootController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private PlayerManager manager;
        [SerializeField] private List<Component> gunControllers; //We use "Component" reference to see interfaces in Unity Inspector.
        [SerializeField] private List<GameObject> gunMeshes;
        #endregion
        #region Private Variables
        private PlayerData _data;
        private IGun _currentGun;

        private bool _isNotStarted = true;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = manager.GetData();
            _currentGun = (IGun)gunControllers[0];
            gunMeshes[0].SetActive(true);
        }



        public void OnClicked(Vector3 pos)
        {
            _currentGun.Shoot(pos);
        }

        public void OnReleased()
        {
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