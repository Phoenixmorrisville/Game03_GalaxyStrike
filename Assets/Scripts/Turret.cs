using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzle;
    [SerializeField] float aimDistance = 21f; // camera z = -6, targets z = 15
    void Update()
    {
        AimAtMouse();
        if (Mouse.current.leftButton.wasPressedThisFrame) Fire();
    }
    void AimAtMouse()
    {
        Vector3 screenPos = Mouse.current.position.ReadValue(); // pixels
        screenPos.z = aimDistance; // depth!
        Vector3 point = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 dir = point - transform.position; // destination - origin
        transform.rotation = Quaternion.LookRotation(dir);
    }
    void Fire()
    {
        Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
    }
}