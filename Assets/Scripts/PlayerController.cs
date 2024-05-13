using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0.5f,5f)]
    public float moveSpeed = 2f;

    [Range(0.05f, 1f)]
    public float flipTime;

    private bool facingRight = true;

    public Material shadow;

    private void Update()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;

            if(!facingRight)
            {
                Flip();
            }
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
            if (facingRight)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        StartCoroutine(FlipRoutine());
        facingRight = !facingRight;
    }

    private IEnumerator FlipRoutine()
    {
        var time = 0f;
        var right = facingRight;
        float rotation = 0f;

        if (!right)
            rotation = 180f;
        while(time < flipTime)
        {
            time += Time.deltaTime;

            var rot = transform.rotation;

            var euler = rot.eulerAngles;


            euler.y = Mathf.Lerp(rotation, right ? 180 : 0, time / flipTime);

            transform.rotation = Quaternion.Euler(euler);

            yield return new WaitForEndOfFrame();
        }
    }

    public void EnableShadow()
    {
        StartCoroutine(EnableShadowRoutine());
    }

    private IEnumerator EnableShadowRoutine()
    {
        var time = 0f;
        var color = shadow.color;
        while(time <= 0.2f)
        {
            color.a = Mathf.Lerp(0, 1, time / 0.2f);
            shadow.color = color;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }

    public void DisableShadow()
    {
        StartCoroutine(DisableShadowRoutine());
    }

    private IEnumerator DisableShadowRoutine()
    {
        var time = 0f;
        var color = shadow.color;
        while (time <= 0.2f)
        {
            color.a = Mathf.Lerp(1, 0, time / 0.2f);
            shadow.color = color;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }
}
