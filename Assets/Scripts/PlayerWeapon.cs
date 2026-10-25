using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;

    
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
        
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
         
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = (targetPoint.position - laser.transform.position);
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
