﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeter.Domain
{
    public abstract class Shape
    {
        public int Id { get; set; }
        public Localization Localization { get; set; }
        public int LocalizationId { get; set; }
        [NotMapped]
        abstract public ShapeType Type { get; }

    }
}