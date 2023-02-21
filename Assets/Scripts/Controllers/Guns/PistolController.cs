using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Enums;

public class PistolController : GunController
{
    #region Self Variables
    #region Public Variables

    public override int AmmoCapacity { get; set; } = 15;
    public override int CurrentBulletCount { get; set; } = 15;
    #endregion
    #region Serialized Variables
    #endregion
    #region Private Variables

    #endregion
    #endregion

    public override void Shoot(Vector3 pos)
    {
        GameObject bullet = PoolSignals.Instance.onGetObject(PoolEnums.PistolBullet);
        bullet.transform.position = transform.position;
        bullet.transform.eulerAngles = transform.eulerAngles;

        bullet.SetActive(true);
        --CurrentBulletCount;
        Debug.Log("Pistol Shoot has Triggered.");
    }
    public new void Reload()
    {
        base.Reload();
    }

}
