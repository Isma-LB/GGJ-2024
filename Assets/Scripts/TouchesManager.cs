
using UnityEngine;
using System.Collections.Generic;

public class TouchesManager : MonoBehaviour
{
    public GameObject[] circles;

    private List<GameObject> availableCircles = new List<GameObject>();
    private GameObject[] activeCircles;

    void Start()
    {
        // Populate the list of available circles
        availableCircles.AddRange(circles);

        // Randomly activate three circles without repetition
        activeCircles = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            // Ensure there are available circles to choose from
            if (availableCircles.Count > 0)
            {
                int randomIndex = Random.Range(0, availableCircles.Count);
                activeCircles[i] = availableCircles[randomIndex];
                activeCircles[i].SetActive(true);

                // Remove the selected circle from the available list
                availableCircles.RemoveAt(randomIndex);
            }
            else
            {
                Debug.LogWarning("Not enough circles to activate!");
            }
        }

        // Deactivate the rest of the circles
        foreach (GameObject circle in availableCircles)
        {
            circle.SetActive(false);
        }
    }

    void Update()
    {

        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch detected!");
            // Check if all circles are touched at the same time
            bool allCirclesTouched = true;

            foreach (GameObject circle in activeCircles)
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
            //    sets screen  to yellow color
                Camera.main.backgroundColor = Color.yellow;
                
                
            }
        }
    }
}