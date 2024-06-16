using UnityEngine;

public class BoostButton : TogglableButton
{
    Vector2 translateVector = new Vector2(10,10);

    protected override void DoEffect(bool value)
    {
        if (value)
            transform.Translate(translateVector* Time.deltaTime);
        else
            transform.Translate(-translateVector * Time.deltaTime);

    }
}
