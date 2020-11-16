using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Data
    private ObjectPooler pool; 

    [SerializeField] private Transform platformSpawner;
    #endregion

    #region Methods
    void Start()
    {
        pool = ObjectPooler.SharedInstance;
        pool.GetObject(new Vector3(platformSpawner.position.x, -5f, 0f), new Quaternion(0f, 1f, 0f, 0f), new Vector3(5f, 1f, 2f));
        pool.GetObject(new Vector3(platformSpawner.position.x, 5f, 0f), new Quaternion(0f, 1f, 0f, 0f), new Vector3(5f, 1f, 2f));
    }

    void Update()
    {

    }
    #endregion
}
