using UnityEngine;

public class ParallaxTilingEffect : MonoBehaviour
{
    public Transform cam;  // Reference to the main camera transform
    public float parallaxEffectMultiplier;  // Adjust this to control the parallax effect

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 dist = (cam.position - startPos) * parallaxEffectMultiplier;
        transform.position = new Vector3(startPos.x + dist.x, startPos.y + dist.y, startPos.z);
    }
}
