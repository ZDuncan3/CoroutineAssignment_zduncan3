using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    private GameObject _ball;
    private Rigidbody _rb;
    public GameObject player;

    public Slider slider;
    public GameObject resetPoint;

    public Vector3 extraVelocity;

    void Start()
    {
        StopAllCoroutines();
        _ball = this.gameObject;
        _rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        StartCoroutine(LaunchBall());
        slider.value = extraVelocity.x;

        if (_ball.transform.position.y < resetPoint.transform.position.y)
        {
            _ball.transform.position = new Vector3(0, 0, 0);
        }
    }

    // coroutine 3, launch ball: velocity increase with how long right-click is held
    IEnumerator LaunchBall()
    {
        while (Input.GetMouseButton(1))
        {
            extraVelocity.x += 0.005f;
            extraVelocity.y += 0.005f;
            extraVelocity.z += 0.005f;
            yield return new WaitForSeconds(0.5f);
        }
        _rb.velocity += extraVelocity;
        extraVelocity.x = 0f;
        extraVelocity.y = 0f;
        extraVelocity.z = 0f;
    }
}
