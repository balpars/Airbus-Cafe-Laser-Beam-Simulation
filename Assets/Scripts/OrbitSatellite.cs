using UnityEngine;

public class OrbitSatellite : MonoBehaviour
{
    public float orbitSpeed = 20f;

    void Update()
    {
        transform.Rotate(Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
