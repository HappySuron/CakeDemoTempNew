using UnityEngine;

public class CakeMovement : MonoBehaviour
{
    [Header("Настройки точек движения")]
    public Transform[] waypoints; // Массив точек, по которым будет двигаться объект

    [Header("Параметры движения")]
    public float speed = 2f; // Скорость перемещения объекта
    public int moveFlag = 0; // Флаг, указывающий индекс целевой точки в массиве

    private bool isMoving = false; // Флаг для контроля перемещения

    void Update()
    {
        // Проверяем, что есть точки для движения
        if (waypoints.Length == 0) return;

        // Проверяем, не выходит ли moveFlag за пределы массива
        if (moveFlag >= 0 && moveFlag < waypoints.Length)
        {
            // Начинаем движение к точке, если moveFlag изменился и движение еще не начато
            if (!isMoving)
            {
                isMoving = true; // Включаем флаг движения
            }
        }
        else
        {
            // Если moveFlag вне допустимого диапазона, останавливаем движение
            isMoving = false;
        }

        // Перемещаемся к точке, указанной в moveFlag, если флаг движения включен
        if (isMoving)
        {
            MoveToWaypoint(moveFlag);
        }
    }

    void MoveToWaypoint(int waypointIndex)
    {
        // Определяем цель - точка с индексом moveFlag в массиве
        Transform targetWaypoint = waypoints[waypointIndex];
        Vector3 targetPosition = targetWaypoint.position;

        // Перемещаем объект в сторону цели
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Проверяем, достигли ли мы текущей цели
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false; // Останавливаем движение
        }
    }
}
