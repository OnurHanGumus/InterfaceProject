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
        [SerializeField] private List<Component> gunControllers; //We use "Component" reference to see interfaces in Unity Inspector. Or we can also use their common base class "GunController". 
        [SerializeField] private List<GameObject> gunMeshes;
        #endregion
        #region Private Variables
        private PlayerData _data;
        private IGun _currentGun;

        private int _selectedGunId = 0;
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
            ChangeGun();
        }

        private void ChangeGun()
        {
            _currentGun = (IGun)gunControllers[_selectedGunId];
            for (int i = 0; i < gunControllers.Count; i++)
            {
                gunMeshes[i].SetActive(false);
            }
            gunMeshes[_selectedGunId].SetActive(true);
        }

        public void OnClicked(Vector3 pos)
        {
            transform.LookAt(pos);
            if (_currentGun.CurrentBulletCount <= 0)
            {
                _currentGun.Reload();
            }
            else
            {
                _currentGun.Shoot(pos);
            }
        }

        public void OnReleased()
        {
        }


        public void OnPlay()
        {



        }
        public void OnSelectGun(int gunId)
        {
            _selectedGunId = gunId;
            ChangeGun();
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