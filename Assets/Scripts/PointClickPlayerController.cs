using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointClickPlayerController : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;
    private GameObject _player;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _player = this.gameObject;
        _agent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
        _animator= GetComponent<Animator>();

        if (_camera == null)
        {
            Debug.LogError("No camera is marked as main.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                _agent.destination = hit.point;
            }

            StopAllCoroutines();
            StartCoroutine(WalkAnimation());
        }
    }

    // Coroutine example 1, animations
    IEnumerator WalkAnimation()
    {
        while (_agent.remainingDistance >= _agent.stoppingDistance)
        {
            _animator.SetFloat("InputMagnitude", 0.5f);
            _animator.SetFloat("InputVertical", 0.5f);
            yield return null;
        }
        _animator.SetFloat("InputMagnitude", 0f);
        _animator.SetFloat("InputVertical", 0f);
    }
}
