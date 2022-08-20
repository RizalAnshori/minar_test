using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private MoveableComponent _tankPrefab;
        [SerializeField]
        private Transform _spawnPoint;
        [SerializeField]
        private Vector3 _destination;

        private List<MoveableComponent> _tankPool = new List<MoveableComponent>();
        private ICanTriggerSpawn _spawnTrigger;

        private void OnDisable()
        {
            //add implementation
            _spawnTrigger.TriggerSpawn -= HandleOnSpawnTriggered;
        }

        private void OnEnable()
        {
            //add implementation
            _spawnTrigger.TriggerSpawn += HandleOnSpawnTriggered;
        }

        public void Setup(ICanTriggerSpawn spawnTrigger)
        {
            //add implementation
            _spawnTrigger = spawnTrigger;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnSpawnTriggered()
        {
            //add implementation
            SpawnMoveableObject();
        }

        private void SpawnMoveableObject()
        {
            //add implementation
            var availableTank = GetAvailableTank();
            if(availableTank != null)
            {
                availableTank.gameObject.transform.position = _spawnPoint.position;
                availableTank.gameObject.SetActive(true);
                availableTank.SetDestination(_destination);
            }
            else
            {
                availableTank = Instantiate(_tankPrefab,this.transform);
                availableTank.transform.position = _spawnPoint.position;
                availableTank.SetDestination(_destination);
                _tankPool.Add(availableTank);
            }
        }

        private MoveableComponent GetAvailableTank()
        {
            for(int i = 0; i<_tankPool.Count;i++)
            {
                if(!_tankPool[i].gameObject.activeSelf)
                {
                    return _tankPool[i];
                }
            }
            return null;
        }
    }
}