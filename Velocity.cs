namespace AdvMath
{
    public struct Velocity
    {
        public Vector Direction { get; set; }
        public double Speed { get; set; }

        public Velocity()
        {
            Direction = new Vector(0, 0);
            Speed = 0;
        }

        public Velocity(Vector direction, double speed)
        {
            Direction = direction.Normalize();
            Speed = speed;
        }

        public Vector GetVelocityVector() => Direction * Speed;
    }
}