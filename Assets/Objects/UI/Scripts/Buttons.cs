using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public abstract class Buttons : MonoBehaviour
{
    private void OnEnable() { GetComponent<Button>().onClick.AddListener(OnButtonClick); }

    private void OnDisable() { GetComponent<Button>().onClick.RemoveListener(OnButtonClick); }

    protected abstract void OnButtonClick();
}
