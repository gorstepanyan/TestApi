﻿using System;
using System.Collections.Generic;

namespace TestApi.Data.DbModels;

public partial class VegaBrand
{
    public int Id { get; set; }

    public string VegaBrandName { get; set; } = null!;
}
