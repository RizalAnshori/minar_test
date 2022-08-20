using Project.Components;
using System;
using UnityEngine;

namespace Project.Hometown
{
    public class HouseController : IController, IUpgradeable, ICanTriggerSpawn
    {
        public event Action<LevelupEventData> OnLevelUp;
        public event Action TriggerSpawn;

        private HometownContext _hometownContext;
        private string _itemName;
        private UpgradeableData _upgradeableData;

        private InputManager inputManager;

        public void OnContextDispose()
        {
            //add implementation
            inputManager.OnInputTouch -= HandleOnInputTouch;
        }

        public HouseController(HometownContext hometownContext, string upgradeableItemName, InputManager inputManager)
        {
            _hometownContext = hometownContext;
            _itemName = upgradeableItemName;
            this.inputManager = inputManager;

            //add implementation
            inputManager.OnInputTouch += HandleOnInputTouch;
            new UpgradeableRepository(hometownContext).GetUpgradeableData((data) => _upgradeableData = data);
        }

        public void Upgrade()
        {
            Debug.Log($"Handle Upgrade {_itemName}");
            //add implementation
            if (_upgradeableData.Level < _upgradeableData.MaxLevel)
            {
                _upgradeableData.LevelUp();
                OnLevelUp?.Invoke(new LevelupEventData(level: _upgradeableData.Level, maxLevel: _upgradeableData.MaxLevel));
            }
            else
            {
                TriggerSpawn?.Invoke();
            }
        }

        public void HandleOnInputTouch()
        {
            //add implementation
            if (_upgradeableData == null)
                return;

            Upgrade();
        }
    }
}