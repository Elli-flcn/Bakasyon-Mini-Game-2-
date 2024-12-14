using UnityEngine;
using UnityEngine.EventSystems;

public class Stick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    // Stick control variables
    public RectTransform stickHandle;
    public RectTransform stickBackground;

    // Movement variables
    public float moveSpeed = 5f;
    public Rigidbody2D playerRigidbody;
    public Animator animator;

    private Vector2 movement; // Directional input

    private void Start()
    {
        stickHandle.anchoredPosition = Vector2.zero; // Reset joystick position
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(stickBackground, eventData.position, eventData.pressEventCamera, out position);

        // Calculate the direction and clamp the magnitude
        Vector2 direction = position / (stickBackground.sizeDelta / 2);
        direction = Vector2.ClampMagnitude(direction, 1);

        // Set the handle's position
        stickHandle.anchoredPosition = direction * (stickBackground.sizeDelta.x / 2);

        // Update movement
        movement = direction;
        UpdateAnimation();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stickHandle.anchoredPosition = Vector2.zero; // Reset joystick position on release
        movement = Vector2.zero; // Stop movement
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // Update animator parameters
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // Move the player using Rigidbody2D
        playerRigidbody.velocity = movement * moveSpeed;
    }
}