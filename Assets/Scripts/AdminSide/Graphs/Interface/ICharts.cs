using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharts 
{
    LegendPart LegendPart { get; }

    float FindSum();
}
