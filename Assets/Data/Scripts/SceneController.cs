using System;
using System.Collections;
using System.Collections.Generic;
using TankVsMonsters.Characters;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TankVsMonsters
{
    public class SceneController : MonoBehaviour
    {
        [Inject]
        private BattleUnitManager unitManager;

        [SerializeField]
        private GameObject EndGameUIObject;

        private void Start()
        {
            unitManager.OnUnitDeath += OnUnitDeath;
            EndGameUIObject.SetActive(false);
        }

        private void OnDestroy()
        {
            unitManager.OnUnitDeath += OnUnitDeath;
        }

        private void OnUnitDeath(BattleUnit unit)
        {
            if (unit is MonsterBehaviour)
            {
                return;
            }
            EndGameUIObject.SetActive(true);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
