using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeter.Domain.Shapes
{
    public class Trapeze : Shape
    {
        public double LengthA { get; set; }
        public double LengthB { get; set; }
        public double Height { get; set; }
        [NotMapped]
        public override ShapeType Type => ShapeType.Trapeze;
    }
}