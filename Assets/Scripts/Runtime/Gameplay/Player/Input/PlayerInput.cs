using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay
{
    public class PlayerInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPlayerInput
    {
        private Vector2 _startTouch;
        private Camera _camera;

        public void Init(Camera camera)
        {
            _camera = camera ? camera : throw new ArgumentNullException(nameof(camera));
        }

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
            SwipeDirection = Vector2Int.RoundToInt((currentTouch - _startTouch).normalized);
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