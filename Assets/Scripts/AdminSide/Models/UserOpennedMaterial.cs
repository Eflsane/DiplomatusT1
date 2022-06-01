using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserOpennedMaterial : MonoBehaviour
{
    public string Username { get; set; } = string.Empty;
    public long MaterialId { get; set; }
    public DateTime OpenningDate { get; set; }
}
