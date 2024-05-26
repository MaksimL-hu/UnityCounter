using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{
    public event UnityAction Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Clicked?.Invoke();
    }
}