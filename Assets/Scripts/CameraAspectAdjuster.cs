
using UnityEngine;

// Adjusts the camera size to different screen aspect ratios.
public class CameraAspectAdjuster : MonoBehaviour
{
    // Default camera size for a 16:9 screen.
    [SerializeField] private float baseSize = 5f;

    private Camera cam;

    void Start()
    {
        // Get the camera component.
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Calculate the current screen aspect ratio.
        float aspect = (float)Screen.width / Screen.height;
        float baseAspect = 16f / 9f;

        if (aspect < baseAspect)
        {
            // Zoom out on narrower screens to preserve visible width.
            cam.orthographicSize = baseSize * baseAspect / aspect;
        }
        else
        {
            // Use the default size on wider screens.
            cam.orthographicSize = baseSize;
        }
    }
}
