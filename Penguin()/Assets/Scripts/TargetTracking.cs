using UnityEngine;
// This complete script can be attached to a camera to make it
// continuously point at another object.

public class TargetTracking : MonoBehaviour
{

    public Transform player;

    void Start()
    {
        // Rotate the object every frame so it keeps looking at the target
        player = GameObject.Find("Player").transform;
        transform.LookAt(player);

        // // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        // transform.LookAt(target, Vector3.left);
    }
}
