using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New dialogue", menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    public int index;
    public string[] dialogues;
    public string[] choices;
    public Sprite art;

    public Dialogue[] nextDialogueAnswers;

}
