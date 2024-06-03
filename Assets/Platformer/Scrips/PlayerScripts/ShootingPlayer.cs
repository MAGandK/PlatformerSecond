using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _ballToPool;
    [SerializeField] private int _initialPoolSize = 15;
    
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _spawnInretval = 1.0f; 
    
    private float _timer;

    private List<GameObject> _pooledObjects;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _timer >= _spawnInretval)
        {
            _timer = 0f;
            SpawnObject();
        }
    }
    private void Start()
    {
        _pooledObjects = new List<GameObject>();
        for (int i = 0; i < _initialPoolSize; i++)
        {
            GameObject obj = Instantiate(_ballToPool);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }
    
    public GameObject GetPooledObject()
    {
        foreach (var obj in _pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        
        GameObject newObj = Instantiate(_ballToPool);
        newObj.SetActive(false);
        _pooledObjects.Add(newObj);
        return newObj;
    }
        
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
    
    private void SpawnObject()
    { 
        GameObject ball = GetPooledObject();
        if (ball != null)
        {
            ball.transform.position = _shootingPoint.transform.position;
            ball.transform.rotation = _shootingPoint.transform.rotation;
            ball.SetActive(true);
        }
    }
}
