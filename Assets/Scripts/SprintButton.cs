using UnityEngine;
using UnityEngine.UI;
internal class SprintButton : TogglableButton
{

    [SerializeField]
    protected Image nkar;

    protected override void DoEffect(bool value)
    {
        if (value)
            nkar.color = Color.red;
        else
            nkar.color = Color.green;
    }
}