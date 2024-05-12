using UnityEngine;

public class Wobble : MonoBehaviour
{
    [Range(1f,180f)]
    public float angleFactor;

    void Update()
    {
        var rot = transform.rotation.eulerAngles;

        rot.z = Mathf.Cos(Time.time);

        transform.rotation = Quaternion.Euler(rot * angleFactor);
    }
}
