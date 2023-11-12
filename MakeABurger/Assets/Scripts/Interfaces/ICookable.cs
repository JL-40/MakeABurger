using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICookable
{
    public IEnumerator StartCooking();

    public void StopCooking();
}
