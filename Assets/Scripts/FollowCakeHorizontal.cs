using UnityEngine;

public class FollowCakeHorizontal : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public float fixedY = 0f; // Фиксированное значение по Y для камеры (можете задать свое значение)
    public float smoothSpeed = 0.125f; // Скорость сглаживания

    void LateUpdate()
    {
        if (player == null) return;

        // Получаем только X позицию игрока, Y оставляем фиксированным
        Vector3 desiredPosition = new Vector3(player.position.x, fixedY, transform.position.z);
        // Сглаживаем переход для плавности
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
