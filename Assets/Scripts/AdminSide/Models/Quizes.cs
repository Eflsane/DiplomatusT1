using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Quizes
{
    public long ID { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int MaxScore { get; set; } = 0;

    public DateTime CreationDate { get; set; }
}
