namespace FlowMeter.Domain
{
    public abstract class Shape
    {
        public int Id { get; set; }
        public ShapeType Type { get; set; }
    }
}