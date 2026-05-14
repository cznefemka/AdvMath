namespace AdvMath
{
    public struct Velocity
    {
        public Vector Direction { get; set; }
        private double Speed { get; set; }

        public Velocity() // Default constructor initializes velocity to zero speed and no direction
        {
            Direction = new Vector(0, 0);
            Speed = 0;
        }

        public Velocity(Vector direction) // Constructor to initialize only the direction, speed defaults to 1
        {
            Direction = direction.Normalize();
            Speed = direction.Length(); // Set speed based on the length of the direction vector for more intuitive initialization
        }

        public Velocity(Vector direction, double speed) // Constructor to initialize both direction and speed
        {
            Direction = direction.Normalize();
            Speed = speed;
        }

        public Vector GetVelocityVector() => Direction * Speed; // Get the velocity as a vector by multiplying the direction by the speed
        public double GetSpeed() => Direction.Length() * Speed; // Get the speed component of the velocity

        public override string ToString() // Override ToString for easy debugging and visualization of the velocity's state
        {
            return $"Direction: {Direction}, Speed: {GetSpeed():F4}";
        }
    }
}