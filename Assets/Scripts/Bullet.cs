using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 25f;
    void Start()
    {
        Destroy(gameObject, 3f); // remove this bullet after 3 seconds
    }
    void Update()
    {
        // move forward along the bullet's blue Z axis every frame
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Target")
        {

            other.GetComponent<Target>().TakeDamage(1);
            Destroy(gameObject);

        }
    }





}