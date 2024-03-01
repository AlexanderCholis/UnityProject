using UnityEngine;

public class PaintBlack : MonoBehaviour
{
    void Start()
    {
        // Assuming the object has a renderer component and a material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // Create a new material instance so that changes are not applied globally
            Material material = new Material(renderer.sharedMaterial);
            material.color = Color.black; // Set the material color to black
            renderer.material = material; // Assign the new material to the object
        }
        else
        {
            Debug.LogError("Renderer component not found!");
        }
    }
}
