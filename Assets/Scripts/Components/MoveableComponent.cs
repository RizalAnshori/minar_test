using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class MoveableComponent : MonoBehaviour
    {
        [SerializeField] private float duration;
        private Vector3 _destination;

        public void SetDestination(Vector3 destination)
        {
            //add implementation to move this object to destination
            //and destroy it when it reach the destination
            //desination must be some vector3 where y and z coordinate not change from current coordinate
            //only x coordinate change and to positive direction (to the right)
            _destination = new Vector3(destination.x, transform.position.y, transform.position.z);
            StartCoroutine(MoveIE());
        }

        private IEnumerator MoveIE()
        {
            float curTime = 0;
            Vector3 startPos = transform.position;
            while(curTime < duration)
            {
                transform.position = Vector3.Lerp(startPos, _destination, curTime / duration);
                curTime += Time.deltaTime;
                yield return null;
            }
            transform.position = _destination;
            yield return new WaitForEndOfFrame();
            this.gameObject.SetActive(false);
        }
    }
}