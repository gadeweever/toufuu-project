﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    #region Variables
    public Transform body;
    public float speed;
    public float damage;
    public Pather path;
    #endregion 

 

    void Update()
    {
        Move();

    }

    void Move()
    {
        Vector3 positionNew = transform.position + Vector3.up * 2f;
        transform.position = Vector3.Lerp(transform.position, positionNew, speed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    void Start()
    {
        damage = 50;
    }

    
}
