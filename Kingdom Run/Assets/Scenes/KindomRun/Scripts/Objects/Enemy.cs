using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;

    private Animator _animator;

    private bool _isStop;

    private float delayTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.On("using_enemystop", OnUseEnemyStop);
        EventManager.On("game_ended", Hide);
    }

    private void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _isStop = false;
    }
    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);

        if (_isStop)
            StartCoroutine(WaitMove());

    }
    public void ForwardTarget(object obj)
    {
        GameObject target = GameObject.Find("Portal");
        if(target)
            _agent.SetDestination(target.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Portal"))
        {
            GameManager.Instance.SetEndState(false);
            EventManager.Emit("game_ended");
        }
    }

    private void Hide(object obj) => gameObject.SetActive(false);
    
    private void OnUseEnemyStop(object obj)
    {
        _isStop = true;
    }

    IEnumerator WaitMove()
    {
        _agent.isStopped = true;
        _agent.velocity = Vector3.zero;
        yield return new WaitForSeconds(delayTime);
        _isStop = false;
        _agent.isStopped = false;
    }
}
