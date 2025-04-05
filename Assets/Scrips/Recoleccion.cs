using UnityEngine;

public class Recoleccion : MonoBehaviour
{
  

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recolector"))  // Detecta si tocó una moneda
        {
            Destroy(other.gameObject);  // Elimina la moneda
        }
    }
}