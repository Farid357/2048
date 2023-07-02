using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay
{
    public class PlayerInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPlayerInput
    {
        [SerializeField] private Camera _camera;
        
        private Vector2 _startTouch;

        public Vector2Int SwipeDirection { get; private set; } = Vector2Int.zero;

        public bool IsUp { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            _startTouch = _camera.ScreenToWorldPoint(eventData.position);
            SwipeDirection = Vector2Int.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 currentTouch = _camera.ScreenToWorldPoint(eventData.position);
            SwipeDirection = Vector2Int.RoundToInt(((currentTouch - _startTouch) * 4f).normalized);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsUp = true;
        }

        public void ResetSwipeAll()
        {
            IsUp = false;
            SwipeDirection = Vector2Int.zero;
        }
    }
}