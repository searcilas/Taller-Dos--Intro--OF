using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDetection : MonoBehaviour
{

    private Rigidbody2D _rb;
    [SerializeField] private GameObject _bullet;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(_bullet);
    }


}


