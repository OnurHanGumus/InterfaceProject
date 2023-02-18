using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Enums;

public class PoolManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private GameObject pistolBulletPrefab, shotgunBulletPrefab, rocketBulletPrefab;
    [SerializeField] private GameObject particlePrefab;

    [SerializeField] private Dictionary<PoolEnums, List<GameObject>> poolDictionary;


    [SerializeField] private int amountBullet = 20;
    [SerializeField] private int amountParticle = 5;



    #endregion
    #region Private Variables
    private int _levelId = 0;
    #endregion
    #endregion
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _levelId = LevelSignals.Instance.onGetCurrentModdedLevel();
        poolDictionary = new Dictionary<PoolEnums, List<GameObject>>();
        InitializePool(PoolEnums.PistolBullet, pistolBulletPrefab, amountBullet);
        InitializePool(PoolEnums.ShotgunBullet, shotgunBulletPrefab, amountBullet);
        InitializePool(PoolEnums.RocketBullet, rocketBulletPrefab, amountBullet);
    }



    #region Event Subscriptions

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        PoolSignals.Instance.onGetPoolManagerObj += OnGetPoolManagerObj;
        PoolSignals.Instance.onGetObjectOnPosition += OnGetObjectOnPosition;
        PoolSignals.Instance.onGetObject += OnGetObject;
        CoreGameSignals.Instance.onRestartLevel += OnReset;

    }

    private void UnsubscribeEvents()
    {
        PoolSignals.Instance.onGetPoolManagerObj -= OnGetPoolManagerObj;
        PoolSignals.Instance.onGetObjectOnPosition -= OnGetObjectOnPosition;
        PoolSignals.Instance.onGetObject -= OnGetObject;
        CoreGameSignals.Instance.onRestartLevel -= OnReset;

    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    #endregion

    private void InitializePool(PoolEnums type, GameObject prefab, int size)
    {
        List<GameObject> tempList = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < size; i++)
        {
            tmp = Instantiate(prefab, transform);
            tmp.SetActive(false);
            tempList.Add(tmp);
        }
        poolDictionary.Add(type, tempList);
    }

    public GameObject OnGetObject(PoolEnums type)
    {
        for (int i = 0; i < poolDictionary[type].Count; i++)
        {
            if (!poolDictionary[type][i].activeInHierarchy)
            {
                return poolDictionary[type][i];
            }
        }
        return null;
    }
    public GameObject OnGetObjectOnPosition(PoolEnums type, Vector3 position)
    {
        for (int i = 0; i < poolDictionary[type].Count; i++)
        {
            if (!poolDictionary[type][i].activeInHierarchy)
            {
                poolDictionary[type][i].transform.position = position;
                poolDictionary[type][i].gameObject.SetActive(true);

                return poolDictionary[type][i];
            }
        }
        return null;
    }

    public Transform OnGetPoolManagerObj()
    {
        return transform;
    }


    private void OnReset()
    {
        //reset
        ResetPool(PoolEnums.PistolBullet);
        ResetPool(PoolEnums.ShotgunBullet);
        ResetPool(PoolEnums.RocketBullet);
    }

    private void ResetPool(PoolEnums type)
    {
        foreach (var i in poolDictionary[type])
        {
            i.SetActive(false);
        }
    }
}
