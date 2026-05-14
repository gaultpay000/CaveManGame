using UnityEngine;
using AICore;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class BTAgent : AIAgentBase
    {
        [SerializeField] private BehaviorTreeGraph btGraph;
        [SerializeField] private Transform[] _waypoints;

        Dictionary<string, object> _blackboard;

        Rigidbody rb;
        
        public Dictionary<string, object> GetBlackboard { get {  return _blackboard; } }

        protected override void Start()
        {
            base.Start();
            rb = GetComponent<Rigidbody>();

            _blackboard = new Dictionary<string, object>();
            _blackboard.Add("Waypoints", _waypoints);
            _blackboard.Add("WaypointIndex", 0);

            if (btGraph != null)
            {
                btGraph = btGraph.Copy() as BehaviorTreeGraph; 
                btGraph.InitBehaviorTree(this);
            }
        }

        protected override void FixedUpdate()
        {

            rb.linearVelocity = Vector3.zero;

            AssessTargets();

            if(btGraph != null && btGraph.RootNode != null)
            {
                btGraph.Update();
            }

            base.FixedUpdate(); //clear target stuff
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>() != null) 
            {
                StartCoroutine(FindAnyObjectByType<EnemyAnimationController>().Kick());
                collision.gameObject.GetComponent<PlayerMovement>().playerHealth -= 20;
            }
            
        }
    }
}
