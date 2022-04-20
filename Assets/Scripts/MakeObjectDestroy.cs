using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectDestroy : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        ObjectPoolScripts.Instance.BackToPool(gameObject);
    }
}
