using UnityEngine;

// Keeps every object the same size on screen when the device rotates
// between landscape and portrait, by changing only the camera's orthographicSize.
public class CameraAspectAdjuster : MonoBehaviour
{
    // Camera size in landscape: half of the visible world height, in world units.
    [SerializeField] private float landscapeSize = 5f;

    private Camera cam;
    private int lastWidth;
    private int lastHeight;

    void Awake()
    {
        // Get the camera component.
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Recalculate only when the screen size or orientation changes.
        if (Screen.width == lastWidth && Screen.height == lastHeight)
        {
            return;
        }

        lastWidth = Screen.width;
        lastHeight = Screen.height;

        // orthographicSize is half of the visible height in world units.
        // On screen, one world unit takes (screen height / (2 * size)) pixels.
        // To keep that the same after rotating, the size must grow with the
        // screen height relative to the short side of the screen.
        int shortSide = Mathf.Min(Screen.width, Screen.height);
        cam.orthographicSize = landscapeSize * Screen.height / shortSide;
    }
}
