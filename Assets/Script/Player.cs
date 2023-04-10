using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera viewCam;
    //
    PlayerController controller;
    GunController gunController;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        Vector3 moveInput = new(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //GetAxisRaw不带平滑修正，GetAxis则自带平滑修正
        //Vector3 moveInput = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);
        //LookAt
        Ray camRay = viewCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(camRay,out rayLength))
        {
            Vector3 focusPoint = camRay.GetPoint(rayLength);
            Debug.DrawLine(camRay.origin,focusPoint,Color.cyan);
            controller.PlayerLookAt(focusPoint);
        }
        //Weapon
        if (Input.GetMouseButton(0))
        {
            gunController.PullTrigger();
        }
    }
}
