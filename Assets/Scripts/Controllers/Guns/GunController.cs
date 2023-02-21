using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunController : MonoBehaviour, IGun
{
    public virtual int AmmoCapacity { get; set; }
    public virtual int CurrentBulletCount { get; set; }
    public abstract void Shoot(Vector3 pos);
    public void Reload()
    {
        CurrentBulletCount = AmmoCapacity;
        Debug.Log("Reloaded");
    }

    
}
