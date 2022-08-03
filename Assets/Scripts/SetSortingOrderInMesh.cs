using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SetSortingOrderInMesh : MonoBehaviour
{
    [SerializeField] private int _sortingOrder;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().sortingOrder = _sortingOrder;
    }
}
