using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform _shootPoint;

    [SerializeField] private Transform _shootPoint2;
    [SerializeField] public float timeRemaining = 3;
    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        
        if (timeRemaining < 0)
        {
            //Shoot
            GameObject projectile1 = Instantiate(_projectilePrefab);
            projectile1.transform.position = _shootPoint.position;
            projectile1.transform.rotation = _shootPoint.rotation;
            
            GameObject projectile2 = Instantiate(_projectilePrefab);

            projectile2.transform.position = _shootPoint2.position;
            projectile2.transform.rotation = _shootPoint2.rotation;
            timeRemaining = 2;
        }
    }
}