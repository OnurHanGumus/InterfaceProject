using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Enums;

public class ShotgunController : GunController
{
    #region Self Variables
    #region Public Variables

    public override int AmmoCapacity { get; set; } = 7;
    public override int CurrentBulletCount { get; set; } = 7;

    #endregion
    #region Serialized Variables
    #endregion
    #region Private Variables

    #endregion
    #endregion

    public override void Shoot(Vector3 pos)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = PoolSignals.Instance.onGetObject(PoolEnums.ShotgunBullet);
            bullet.transform.position = transform.position + new Vector3(Random.Range(-0.5f, 0.6f), Random.Range(-0.5f, 0.6f), 0);
            bullet.transform.eulerAngles = transform.eulerAngles;
            bullet.SetActive(true);
        }
        --CurrentBulletCount;


        //bullet.transform.localEulerAngles = new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), Random.Range(-2, 3));
        Debug.Log("Shotgun Shoot has Triggered.");
    }
    public new void Reload()
    {
        base.Reload();
    }

}
