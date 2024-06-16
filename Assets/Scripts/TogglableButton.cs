using UnityEngine;
using UnityEngine.EventSystems;


public abstract class TogglableButton : MonoBehaviour, IPointerDownHandler
{
    bool isClicked;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="is Clicked">whether the button is clicked or not</param>
    protected abstract void DoEffect(bool value);

    protected void Awake()
    {
        isClicked = false;
    }

    protected void Update()
    {
        DoEffect(isClicked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = !isClicked;
    }


}
