using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    #region Data
    [SerializeField] private float _speed;

    #endregion

    #region Methods
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }
    #endregion
}
