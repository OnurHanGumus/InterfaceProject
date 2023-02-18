using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Enums;

public class ShotgunController : MonoBehaviour, IGun
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
        GameObject bullet = PoolSignals.Instance.onGetObject(PoolEnums.ShotgunBullet);
        bullet.transform.position = transform.position;
        bullet.transform.eulerAngles = transform.eulerAngles;

        //bullet.transform.localEulerAngles = new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), Random.Range(-2, 3));
        bullet.SetActive(true);
        Debug.Log("Shotgun Shoot has Triggered.");
    }
    public void Reload()
    {
        
    }

}
