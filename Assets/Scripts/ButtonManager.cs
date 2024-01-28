using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public Button[] allButtons;
    private List<Button> availableButtons = new List<Button>();
    private List<Button> selectedButtons = new List<Button>();


    int counterTime = 0;
    int counterToWin = 10;

    void Start()
    {
        // Populate the list of available buttons
        availableButtons.AddRange(allButtons);

        // Randomly select one buttons without repetition
        for (int i = 0; i <1; i++)
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
        counterTime++;

        if (counterTime >= counterToWin)

        {
            GameManager.MiniGameSolved();
          
        }
     
    }
}
