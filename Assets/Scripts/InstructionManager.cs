using UnityEngine;
using System.Collections;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private InstructionSequenceSO instructionSequenceSO;
    [SerializeField] private UiManager instructionUI;
    [SerializeField] private float delayBetweenInstructions = 3f;

    private int currentIndex = 0;
    private Coroutine playRoutine;
    private bool isPlaying = false;

    private void Start()
    {
        PlayInstructionSequence();
    }

    public void PlayInstructionSequence()
    {
        if (instructionSequenceSO == null || instructionSequenceSO.instructions.Length == 0)
            return;

        if (playRoutine != null)
            StopCoroutine(playRoutine);

        playRoutine = StartCoroutine(PlaySequenceCoroutine());
    }

    private IEnumerator PlaySequenceCoroutine()
    {
        isPlaying = true;

        while (currentIndex < instructionSequenceSO.instructions.Length)
        {
            var instruction = instructionSequenceSO.instructions[currentIndex];
            instructionUI.ShowInstruction(instruction.instructionText);

            yield return new WaitForSeconds(delayBetweenInstructions);

            currentIndex++;
        }

        instructionUI.gameObject.SetActive(false);
        isPlaying = false;
    }

    public void ShowInstructionDirectly(InstructionSO instructionSO)
    {
        if (instructionSO == null || instructionUI == null)
            return;

        // Optional: pause the current auto-play if running
        if (playRoutine != null)
            StopCoroutine(playRoutine);

        instructionUI.ShowInstruction(instructionSO.instructionText);
    }

    // Optional: resume after showing manual instruction
    public void ResumeSequence()
    {
        if (!isPlaying)
        {
            playRoutine = StartCoroutine(PlaySequenceCoroutine());
        }
    }
}
