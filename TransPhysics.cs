namespace AdvMath
{
    class TransPhysics
    {
        public const double GravityConstant = 9.81; // Acceleration due to gravity in m/s^2
        public static Vector Move(Vector position, Velocity velocity, double time) =>
            position + velocity.GetVelocityVector() * time; // Move an object based on its velocity vector and time

        public static Vector MoveWithGravity(Vector position, Velocity velocity, double time) =>
            Move(position, ApplyGravity(velocity, time), time); // Move an object while applying gravity to its velocity struct
    
        public static Velocity ApplyGravity(Velocity velocity, double time) =>
            new Velocity(velocity.Direction + new Vector(0, -GravityConstant * time)); // Apply gravity to the velocity by modifying the direction and speed based on the time elapsed
    }
}