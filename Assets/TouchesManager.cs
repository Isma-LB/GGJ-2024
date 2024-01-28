
using UnityEngine;

public class TouchesManager : MonoBehaviour
{
    public GameObject[] circles;

    void Update()
    {
        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            // Check if all circles are touched at the same time
            bool allCirclesTouched = true;

            foreach (GameObject circle in circles)
            {
                bool circleTouched = false;

                // Check each touch
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);

                    // Convert touch position to world coordinates
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    // Check if the touch is over the circle
                    if (circle.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                    {
                        circleTouched = true;
                        break; // No need to check other touches for this circle
                    }
                }

                // If any circle is not touched, set allCirclesTouched to false
                if (!circleTouched)
                {
                    allCirclesTouched = false;
                    break; // No need to check other circles
                }
            }

            // If all circles are touched at the same time, do something
            if (allCirclesTouched)
            {
                Debug.Log("All circles touched simultaneously!");
                // Perform your desired action here
            }
        }
    }
}