using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeter.Domain.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        [NotMapped]
        public override ShapeType Type => ShapeType.Circle;
    }
}