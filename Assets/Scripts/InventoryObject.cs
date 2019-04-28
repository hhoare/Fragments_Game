﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("Name of object to appear in inventory menu UI")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    //TODO: Add long description field
    //TODO: Add icon field

    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = "Pick up " + objectName;
    }

    /// <summary>
    /// When the player itneracts wiht an inventory object, do 2 things:
    /// 1. add inventory object to the playerinventory list
    /// 2. remove object from game world
    ///     disable renderer and collider
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        renderer.enabled = false;
        collider.enabled = false;
    }



}