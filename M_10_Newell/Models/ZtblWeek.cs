using System;
using System.Collections.Generic;

namespace M_10_Newell.Models;

public partial class ZtblWeek
{
    public DateOnly WeekStart { get; set; }

    public DateOnly? WeekEnd { get; set; }
}
