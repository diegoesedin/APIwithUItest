using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tournaments model.
/// This is a Scriptable Object for debugging purposes.
/// </summary>
[Serializable]
public class Tournaments : ScriptableObject
{
    public Tournament[] data;
    public Links links;
    public Meta meta;
}