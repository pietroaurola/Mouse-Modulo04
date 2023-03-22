using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction wasd;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        wasd.Enable();
    }

    private void OnDisable()
    {
        wasd.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector2 inputVector = wasd.ReadValue<Vector2>();

        Vector3 finalVector = new Vector3();
        finalVector.x = inputVector.x;
        finalVector.z = inputVector.y;

        controller.Move(finalVector * Time.deltaTime * 3.14f);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(finalVector), 0.15f);
    }
}
