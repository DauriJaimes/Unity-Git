using UnityEngine;

public class Moneda_recoleccion : MonoBehaviour
{
    public int score = 0;  // Variable para contar las monedas

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))  // Detecta si tocó una moneda
        {
            score += 1;  // Suma un punto
            Destroy(other.gameObject);  // Elimina la moneda
        }
    }
}