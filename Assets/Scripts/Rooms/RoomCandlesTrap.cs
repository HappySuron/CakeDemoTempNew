using UnityEngine;

public class RoomCandlesTrap : Room
{
    public GameObject objectToRemove; // Объект, который нужно удалить

    public string requiredTag = "Player"; // Тег для проверки

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DOEEE");
        // Проверяем, является ли объект игроком
        if (other.CompareTag(requiredTag))
        {
            HandleRoomEvent();
        }
    }

    private void HandleRoomEvent()
    {
        // Удаляем указанный объект
        if (objectToRemove != null)
        {
            Destroy(objectToRemove);
            Debug.Log("Объект удален: " + objectToRemove.name);
        }

    }
}
