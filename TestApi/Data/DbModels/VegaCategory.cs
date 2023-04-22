﻿using System;
using System.Collections.Generic;

namespace TestApi.Data.DbModels;

public partial class VegaCategory
{
    public int Id { get; set; }

    public string VegaObject { get; set; } = null!;

    public bool? VegaKitchen { get; set; }

    public bool? VegaDevice { get; set; }

    public bool? VegaFurniture { get; set; }
}
