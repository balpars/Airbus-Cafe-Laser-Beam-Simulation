using UnityEngine;

public class SpaceDebris : MonoBehaviour
{
    public Transform earth;  // Referenz zur Erde

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            FallToEarth();
        }
    }

    void FallToEarth()
    {
        Vector3 directionToEarth = (earth.position - transform.position).normalized;
        rb.AddForce(directionToEarth * 10f, ForceMode.Impulse);  // Kraft zum Fallen zur Erde
    }
}
