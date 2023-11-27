using System.Collections;
using System.Collections.Generic;
using TankVsMonsters.Characters;
using UnityEngine;

namespace TankVsMonsters
{

    public sealed class TankContoller : MonoBehaviour
    {
        [SerializeField]
        private TankBehaviour tank;

        private Vector3 inputAxis = Vector3.zero;

        public void Start()
        {
            tank = GetComponent<TankBehaviour>();
        }


        private void Update() 
        {
            InputUpdate();
        }

        private void FixedUpdate()
        {
            if (tank == null)
            {
                return;
            }
            tank.Move(inputAxis);
            tank.Rotate(inputAxis);
        }

        private void InputUpdate()
        {

            inputAxis.x = Input.GetAxis("Horizontal");
            inputAxis.z = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.X))
            {
                tank.Attack();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                tank.SwitchWeaponToPrevious();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                tank.SwitchWeaponToNext();
            }
        }
    }

}
