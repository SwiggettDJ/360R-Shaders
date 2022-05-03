using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
