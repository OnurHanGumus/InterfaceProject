using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    public int AmmoCapacity { get; set; }
    public void Shoot(Vector3 pos);
    public void Reload();
}
