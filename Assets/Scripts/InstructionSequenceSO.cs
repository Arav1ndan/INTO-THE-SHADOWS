using UnityEngine;

[CreateAssetMenu(fileName = "InstructionSequence", menuName = "Game/Instruction Sequence")]
public class InstructionSequenceSO : ScriptableObject
{
    public InstructionSO[] instructions;
}