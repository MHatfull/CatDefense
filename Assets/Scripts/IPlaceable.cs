using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Placeable : MonoBehaviour{
    public abstract int Value { get; }
    public abstract Placeable Clone(Vector3 hitPoint);
}
