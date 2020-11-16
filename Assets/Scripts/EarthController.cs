using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    #region Data
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _movingSpeed = 10f;

    private DirectionEnum _dir = DirectionEnum.Down;
    private bool isGrounded = true;
    #endregion

    #region LifeCycle 
    void Start()
    {
        isGrounded = false; 
    }

    void Update()
    {
        var angle = -1 * _rotationSpeed * Time.deltaTime;
        transform.rotation *= new Quaternion(0f, 0f, Mathf.Sin(angle), Mathf.Cos(angle));
        if(isGrounded && Input.touchCount > 0)
        {
            ChangeDirection();
        }
    }
    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            transform.Translate(0f, (int)_dir * _movingSpeed, 0f, Space.World);
        }
    }
    #endregion


    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        Debug.Log("Earth was triggered " + other.name); 
    }

    private void ChangeDirection()
    {
        _dir = (DirectionEnum)(-1 * (int)_dir);
        _rotationSpeed *= -1;
        isGrounded = false;
    }
    #endregion
}
