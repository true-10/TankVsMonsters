using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankVsMonsters
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField]
        private Transform targetTransform;
        [SerializeField]
        private bool followPosition = true;
        [SerializeField]
        private bool followRotaion = false;


        private Transform cachedTransform;

        private void OnValidate()
        {
            cachedTransform = GetComponent<Transform>();
        }

        public void SetTarget(Transform target) => targetTransform = target;

        void LateUpdate()
        {
            Follow();
        }


        [ContextMenu("Follow Now")]
        private void Follow()
        {
            if (followPosition)
            {
                cachedTransform.position = targetTransform.position;
            }
            if (followRotaion)
            {
                cachedTransform.rotation = targetTransform.rotation;
            }
        }
    }
}
