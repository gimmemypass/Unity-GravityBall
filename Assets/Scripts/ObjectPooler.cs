using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("Pool")]
public class ObjectPooler : MonoBehaviour
{
    #region Data
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledObjects;

    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    #endregion

    #region Interface
    public GameObject GetObject(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        GameObject ret;
        var disactiveObjects = pooledObjects
                                    .Where(o => o.activeInHierarchy == false)
                                    .ToList();
        if(disactiveObjects.Count > 0)
        {
            ret = disactiveObjects[0];
        }
        else
        {
            ret = Instantiate(objectToPool) as GameObject;
        }

        ret.transform.position = position;
        ret.transform.rotation = rotation;
        ret.transform.localScale = scale;
        ret.SetActive(true);
        return ret;
    }
    #endregion

    #region Methods
    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < amountToPool; i++)
        {
            AddObject();    
        }
    }

    private void AddObject()
    {
        GameObject obj = Instantiate(objectToPool) as GameObject;
        obj.SetActive(false);
        pooledObjects.Add(obj);
    }
    #endregion
}
