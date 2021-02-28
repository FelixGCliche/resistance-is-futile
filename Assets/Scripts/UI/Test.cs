using System;
using UnityEngine;

namespace UI
{
  public class Test : MonoBehaviour
  {
    [SerializeField]
    private Character parent;
    private Canvas canvas;

    private void Awake()
    {
      canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
      canvas.transform.position = parent.transform.position;
    }
  }
}