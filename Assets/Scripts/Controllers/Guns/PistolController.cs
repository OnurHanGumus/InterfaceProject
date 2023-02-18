using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Enums;

public class PistolController : MonoBehaviour, IGun
{
    #region Self Variables
    #region Public Variables
    public int CurrentAmmoCount;

    public int AmmoCapacity { get; set; }
    #endregion
    #region Serialized Variables
    #endregion
    #region Private Variables

    #endregion
    #endregion

    public void Shoot(Vector3 pos)
    {
        PoolSignals.Instance.onGetObject(PoolEnums.PistolBullet);
        Debug.Log("Pistol Shoot has Triggered.");
    }
    public void Reload()
    {
        
    }

}
