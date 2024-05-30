using UnityEngine;

public class OrbitController : MonoBehaviour
{
    // Speed of the orbit
    public float orbitSpeed = 10.0f;

    void Update()
    {
        // Rotate the parent object around its Y axis
        transform.Rotate(Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
