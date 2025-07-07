using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    private readonly float minDistanceForSwipe = 20f;

    [SerializeField]
    private Player player;
    public Player Player {get => player;}

    private void Update()
    {
        #if UNITY_EDITOR_WIN
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Swipe(SwipeDirection.Left);

            if (Input.GetKeyDown(KeyCode.RightArrow))
                Swipe(SwipeDirection.Right);
        #endif
        
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
            Swipe(direction);
        }
    }

    private void Swipe(SwipeDirection direction)
    {
        if(player != null)
            player.OnSwipe(direction);
    }

    private bool SwipeDistanceCheckMet()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x) > minDistanceForSwipe;
    }
}