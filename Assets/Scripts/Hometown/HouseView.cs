using UnityEngine;

namespace Project.Hometown
{
    public class HouseView : MonoBehaviour
    {
        [SerializeField] private Transform _houseTransform;

        private HouseController _houseController;
        Vector3 _startingScale;

        private void OnDisable()
        {
            //add implementation
            _houseController.OnLevelUp -= HandleOnHouseLevelUp;
        }

        private void OnEnable()
        {
            //add implementation
            _houseController.OnLevelUp += HandleOnHouseLevelUp;
        }

        public HouseView Setup(HouseController houseController)
        {
            _houseController= houseController;
            _startingScale = _houseTransform.localScale;
            return this;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnHouseLevelUp(LevelupEventData data)
        {
            //add implementation
            float _scaleIncrement = (float)data.Level / (float)data.MaxLevel;
            
            _houseTransform.localScale = new Vector3(_startingScale.x+_scaleIncrement,_startingScale.y+_scaleIncrement,_startingScale.z);
        }
    }
}