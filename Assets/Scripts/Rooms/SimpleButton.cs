using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public Trap actingObjext; // Объект, который нужно удалить

    public string requiredTag = "Player"; // Тег для проверки

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(requiredTag))
        {
            ActivateObject();
            Debug.Log("FFFF");
        }
    }

    private void ActivateObject()
    {
        // Удаляем указанный объект
        if (actingObjext != null)
        {
            actingObjext.Act();
        }

    }
}
