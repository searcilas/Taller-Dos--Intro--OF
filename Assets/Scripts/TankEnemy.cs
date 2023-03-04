using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    public Transform tankInitPos;
    public Transform tankEndPos;

    public Transform targetTank;

    public Transform cannon1;
    public Transform cannon2;

    private float _pingPongValue;

    private void Update()
    {
        _pingPongValue = Mathf.PingPong(Time.time / 4f, 1f);
        float yPos = Mathf.Lerp(tankInitPos.position.y, tankEndPos.position.y, _pingPongValue);
        Vector3 newPos = new Vector3(transform.position.x, yPos, transform.position.z);
        transform.position = newPos;

        if (targetTank != null)
        {
            // Obtener la dirección hacia el tanque objetivo
            Vector3 dirToTarget = targetTank.position - transform.position;

            // Proyectar la dirección hacia el objetivo en el plano horizontal y vertical
            Vector3 horizontalDir = Vector3.ProjectOnPlane(dirToTarget, Vector3.up).normalized;
            Vector3 verticalDir = Vector3.ProjectOnPlane(dirToTarget, Vector3.right).normalized;

            // Calcular el ángulo horizontal necesario para rotar los cañones
            float horizontalAngle = Mathf.Atan2(horizontalDir.y, horizontalDir.x) * Mathf.Rad2Deg;

            // Calcular el ángulo vertical necesario para rotar los cañones
            float verticalAngle = Mathf.Asin(verticalDir.y) * Mathf.Rad2Deg;

            // Aplicar la rotación horizontal y vertical a los cañones
            cannon1.localRotation = Quaternion.Euler(0f, 0f, horizontalAngle);
            cannon2.localRotation = Quaternion.Euler(0f, 0f, verticalAngle + horizontalAngle);

            // Calcular la rotación necesaria para apuntar al objetivo
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetTank.position - cannon1.position);

            // Aplicar la rotación a los cañones
            cannon1.rotation = targetRotation;
            cannon2.rotation = targetRotation;


        }
    }
}


