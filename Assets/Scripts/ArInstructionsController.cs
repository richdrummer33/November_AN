using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArInstructionsController : MonoBehaviour
{
    public List<GameObject> steps = new List<GameObject>(); // We need a list of the steps that we will step through

    int currentStepIndex = 0; // We need to take note (remember) what step we are on -- the index of the list

    public GameObject taskSelectionButtons;

    private void OnEnable()
    {
        currentStepIndex = 0; // Start from  first step

        steps[currentStepIndex].SetActive(true); // Activate 1st step

        taskSelectionButtons.SetActive(false); // Disable the buttons since we just selected a task
    }

    // This method can be called by the "Next Step" button
    public void NextStep()
    {
        steps[currentStepIndex].SetActive(false); // Disable current step

        currentStepIndex = currentStepIndex + 1; // Increment the index (add 1 to the index)

        if(currentStepIndex < steps.Count) // Check that we haven't yet reached end of the list/steps
        {
            steps[currentStepIndex].SetActive(true); // Enable the next one
        }
        else 
        {
            taskSelectionButtons.SetActive(true); // Re-enable task selection options in case the user wants to perform another task

            gameObject.SetActive(false); // Disable this game object (Instructions)
        }
    }
}
