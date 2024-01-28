using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public Button[] allButtons;
    private List<Button> availableButtons = new List<Button>();
    private List<Button> selectedButtons = new List<Button>();
    private List<Button> clickedButtons = new List<Button>();

    void Start()
    {
        // Populate the list of available buttons
        availableButtons.AddRange(allButtons);

        // Randomly select three buttons without repetition
        for (int i = 0; i < 3; i++)
        {
            // Ensure there are available buttons to choose from
            if (availableButtons.Count > 0)
            {
                int randomIndex = Random.Range(0, availableButtons.Count);
                Button selectedButton = availableButtons[randomIndex];
                selectedButtons.Add(selectedButton);

                // Attach click event handler to the selected button
                selectedButton.onClick.AddListener(() => ButtonClicked(selectedButton));

                // Remove the selected button from the available list
                availableButtons.RemoveAt(randomIndex);
            }
            else
            {
                Debug.LogWarning("Not enough buttons to select!");
            }
        }

        // Deactivate the rest of the buttons
        foreach (Button button in availableButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    void ButtonClicked(Button clickedButton)
    {
        // Log a message when any button is clicked
        Debug.Log("Button Clicked: " + clickedButton.name);

        // Add the clicked button to the list
        clickedButtons.Add(clickedButton);

        // Check if all selected buttons are clicked simultaneously
        if (clickedButtons.Count == selectedButtons.Count)
        {
            bool allButtonsClickedSimultaneously = true;

            // Check if all selected buttons are in the clickedButtons list
            foreach (Button selectedButton in selectedButtons)
            {
                if (!clickedButtons.Contains(selectedButton))
                {
                    allButtonsClickedSimultaneously = false;
                    break;
                }
            }

            if (allButtonsClickedSimultaneously)
            {
                Debug.Log("All selected buttons clicked simultaneously!");
                // Perform your desired action here
                GameManager.MiniGameSolved();
                // Clear the clicked buttons list for the next round
                clickedButtons.Clear();
            }
        }
    }
}
