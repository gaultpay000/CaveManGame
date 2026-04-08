using UnityEngine;

namespace AICore
{
    [RequireComponent(typeof(SphereCollider))]
    public class AITrigger : MonoBehaviour
    {
        [SerializeField] private AIAgentBase _agent;
        [SerializeField] private SphereCollider _collider;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.isTrigger = true;

            if(transform.parent.GetComponentInChildren<AIAgentBase>() != null)
            {
                _agent = transform.parent.GetComponentInChildren<AIAgentBase>();
            }
            else
            {
                Debug.LogError("Trigger parent doesn't have an agent in its children");
            }
        }

        public void SetRadius(float r)
        {
            _collider.radius = r;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_agent == null || other.transform != _agent.transform)
            {
                return;
            }

            _agent.HasReachedDestination = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (_agent == null || other.transform != _agent.transform)
            {
                return;
            }

            _agent.HasReachedDestination = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (_agent == null || other.transform != _agent.transform)
            {
                return;
            } 

            _agent.HasReachedDestination = false;
        }
    }
}
