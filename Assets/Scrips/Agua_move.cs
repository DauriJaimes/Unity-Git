using UnityEngine;

public class NewEmptyCSharpScript : MonoBehaviour
{



    public Material waterMaterial;
    public float speedX = 0.1f;  // Velocidad en el eje X
    public float speedY = 0.05f; // Velocidad en el eje Y

    void Update()
    {
        float offsetX = Time.time * speedX;
        float offsetY = Time.time * speedY;
        waterMaterial.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}

