using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;

public class StoreController : MonoBehaviour
{
    public void SelectGun(int gunId)
    {
        PlayerSignals.Instance.onSelectGun?.Invoke(gunId);
    }
}
