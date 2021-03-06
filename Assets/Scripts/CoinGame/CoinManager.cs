﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using crass;

public class CoinManager : Singleton<CoinManager>
{
    public int BasketSize;

    public FallingObjectBag SpawnPool;
    public float SpawnTime;
    public float SpawnHeight;
    public Vector2 SpawnXBounds;

    public Text BasketDisplay;

    public int BasketCount
    {
        get
        {
            return _basketCount;
        }
        set
        {
            _basketCount = value;
            if (_basketCount == 0)
            {
                SceneManager.LoadScene("LivingRoom");
            }
        }
    }

    [SerializeField]
    int _basketCount;

    float spawnTimer;

    void Awake ()
    {
        SingletonSetInstance(this, true);
    }

    void Start ()
    {
        _basketCount = BasketSize;
    }

    void Update ()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = SpawnTime;

            float x = Random.Range(SpawnXBounds.x, SpawnXBounds.y);
            Instantiate(SpawnPool.GetNext(), new Vector2(x, SpawnHeight), Quaternion.identity);
        }

        BasketDisplay.text = BasketCount.ToString();
    }
}

[System.Serializable]
public class FallingObjectBag : BagRandomizer<FallingObject> {}