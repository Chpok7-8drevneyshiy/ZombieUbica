using UnityEngine;
public class Look : MonoBehaviour
{
    public float mouseSensitivity = 100f; // кэф чувствительности
    public Transform Controller; // сам объект FPS
    float xRotation = 0f; // переменная, в которую записывается постоянно меняющееся значение поворота

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // Ограничение угла обзора сверху и снизу, по 90 градусов каждое
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Controller.Rotate(Vector3.up * mouseX); //Поворот камеры по оси Х
    }
}
