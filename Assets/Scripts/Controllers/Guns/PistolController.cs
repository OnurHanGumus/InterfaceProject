using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Enums;

public class PistolController : MonoBehaviour, IGun
{
    #region Self Variables
    #region Public Variables

    public int AmmoCapacity { get; set; } = 15;
    public int CurrentBulletCount { get; set; } = 15;
    #endregion
    #region Serialized Variables
    #endregion
    #region Private Variables

    #endregion
    #endregion

    public void Shoot(Vector3 pos)
    {
        GameObject bullet = PoolSignals.Instance.onGetObject(PoolEnums.PistolBullet);
        bullet.transform.position = transform.position;
        bullet.transform.eulerAngles = transform.eulerAngles;

        bullet.SetActive(true);
        --CurrentBulletCount;
        Debug.Log("Pistol Shoot has Triggered.");
    }
    public void Reload()
    {
        CurrentBulletCount = AmmoCapacity;
        Debug.Log("Reloaded");
    }

}
