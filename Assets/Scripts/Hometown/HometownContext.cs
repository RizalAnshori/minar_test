using Project.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Hometown
{
    [RequireComponent(typeof(InputManager) , typeof(Spawner))]
    public class HometownContext : MonoBehaviour
    {
        [SerializeField]
        private InputManager _inputManager;
        [SerializeField]
        private Spawner _spawner;
        [SerializeField]
        private HouseView _houseView;

        public HouseController HouseController { get; private set; }
        

        private void Awake()
        {
            if(_inputManager == null)
            {
                _inputManager = GetComponent<InputManager>();
            }

            if (_spawner == null)
            {
                _spawner =  GetComponent<Spawner>();
            }

            //add implementation
            if (_houseView == null)
            {
                _houseView = FindObjectOfType<HouseView>();
            }

            HouseController = new HouseController(this, "House", _inputManager);
            
            _houseView.Setup(HouseController);
            _houseView.EnableScript();

            _spawner.Setup(HouseController);
            _spawner.EnableScript();
        }

        private void OnDestroy()
        {
            //add implementation
            HouseController.OnContextDispose();
        }

    }
}