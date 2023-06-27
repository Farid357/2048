using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay
{
    public class PlayerInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPlayerInput
    {
        private Vector2 _startTouch;
        private Camera _camera;

        public Vector2 SwipeDirection { get; private set; } = Vector2.zero;

        public void Init(Camera camera)
        {
            _camera = camera ? camera : throw new ArgumentNullException(nameof(camera));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _startTouch = _camera.ScreenToWorldPoint(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 currentTouch = _camera.ScreenToWorldPoint(eventData.position);
            SwipeDirection = (currentTouch - _startTouch).normalized;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            SwipeDirection = Vector2.zero;
        }
    }
}