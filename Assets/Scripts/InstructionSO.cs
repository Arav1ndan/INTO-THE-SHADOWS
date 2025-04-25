using UnityEngine;

[CreateAssetMenu(fileName = "NewInstruction", menuName = "Game/Instruction")]
public class InstructionSO : ScriptableObject
{
    [TextArea(2, 5)]
    public string instructionText;
}
