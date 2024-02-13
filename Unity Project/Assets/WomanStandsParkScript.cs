using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanStandsParkScript : ScriptableObject
{
    public string question;
    [Tooltip("The correct answer should be listed first, they are dandomized later")]
    public string[] answers;

}
