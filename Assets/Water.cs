using UnityEngine;

public class Water : MonoBehaviour
{
    public Material material;

    private void Update()
    {
        material.mainTextureOffset = Vector2.left * Mathf.Sin(Time.time) * 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<PlayerController>().DisableShadow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<PlayerController>().EnableShadow();
        }
    }
}
