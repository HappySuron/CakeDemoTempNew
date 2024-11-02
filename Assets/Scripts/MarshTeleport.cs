using UnityEngine;

public class MarshTeleport : MonoBehaviour
{
    public Camera mainCamera; // Ссылка на основную камеру
    public Transform teleportCenter; // Центр, вокруг которого будем телепортироваться
    public float teleportRadius = 2f; // Радиус телепортации вокруг центра
    public float offset = 0.5f; // Небольшой отступ для выхода за экран
    public GameObject poofEffect; // Эффект для появления и исчезновения
    public float effectDuration = 0.1f; // Время, через которое "пооф" эффект удаляется

    void Update()
    {
        Vector3 screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, mainCamera.nearClipPlane));
        Vector3 screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, mainCamera.nearClipPlane));
        Vector3 screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0, mainCamera.nearClipPlane));
        Vector3 screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1, mainCamera.nearClipPlane));

        bool isTeleported = false;

        // Проверка горизонтальных границ
        if (transform.position.x < screenLeft.x - offset || transform.position.x > screenRight.x + offset)
        {
            isTeleported = true;
        }

        // Проверка вертикальных границ
        if (transform.position.y < screenBottom.y - offset || transform.position.y > screenTop.y + offset)
        {
            isTeleported = true;
        }

        if (isTeleported)
        {
            // Создаем "пооф" эффект в точке, где объект исчезает
            // GameObject disappearEffect = Instantiate(poofEffect, transform.position, Quaternion.identity);
            // Destroy(disappearEffect, effectDuration); // Удаляем эффект через 0.1 секунды

            // Выбираем новую позицию в радиусе вокруг объекта "teleportCenter"
            Vector2 randomOffset = Random.insideUnitCircle * teleportRadius;
            Vector3 newPosition = new Vector3(teleportCenter.position.x + randomOffset.x, teleportCenter.position.y + randomOffset.y, transform.position.z);
            
            // Телепортируем объект
            transform.position = newPosition;

            // Создаем "пооф" эффект в новой точке
            GameObject appearEffect = Instantiate(poofEffect, newPosition, Quaternion.identity);
            Destroy(appearEffect, effectDuration); // Удаляем эффект через 0.1 секунды
        }
    }
}
