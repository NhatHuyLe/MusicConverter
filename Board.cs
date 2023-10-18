// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class DrawingController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
// {
//     private LineRenderer lineRenderer;
//     private Vector2 previousMousePosition;
//     private bool isDrawing = false;

//     private RectTransform canvasRect;

//     void Start()
//     {
//         // Get the LineRenderer component from the same GameObject
//         lineRenderer = GetComponent<LineRenderer>();
//         lineRenderer.positionCount = 0; // Start with an empty line

//         // Get the RectTransform of the canvas containing this UI element
//         canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
//     }

//     public void OnPointerDown(PointerEventData eventData)
//     {
//         isDrawing = true;
//         lineRenderer.positionCount = 0; // Clear any existing points
//         previousMousePosition = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, transform.position);
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         if (isDrawing)
//         {
//             Vector2 currentMousePosition;
//             RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, eventData.pressEventCamera, out currentMousePosition);

//             // Draw a line segment from the previous position to the current position
//             lineRenderer.positionCount++;
//             lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentMousePosition);

//             previousMousePosition = currentMousePosition;
//         }
//     }

//     public void OnPointerUp(PointerEventData eventData)
//     {
//         isDrawing = false;
//     }
// }
