using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeter.Domain.Shapes
{
    public class Rectangle : Shape
    {
        public double? Lenght { get; set; }
        public double? Height { get; set; }
        [NotMapped]
        public override ShapeType Type => ShapeType.Rectangle;
    }
}