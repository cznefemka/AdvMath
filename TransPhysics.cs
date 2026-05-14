namespace AdvMath
{
    class TransPhysics
    {
        public const double AirDensity = 1.225; // Density of air at sea level in kg/m^3, can be used for drag calculations
        public const double GravityConstant = 9.81; // Acceleration due to gravity in m/s^2
        public static Vector Move(Vector position, Velocity velocity, double time) =>
            position + velocity.GetVelocityVector() * time; // Move an object based on its velocity vector and time
    
        public static Velocity ApplyGravity(Velocity velocity, double time) =>
            new Velocity(velocity.Direction + new Vector(0, -GravityConstant * time)); // Apply gravity to the velocity by modifying the direction and speed based on the time elapsed   

        public static Velocity ApplyPhysics(Velocity velocity, double k, double time) // Apply physics to the velocity by considering both gravity and drag, where k is the drag constant
        {
            return new Velocity((velocity.GetVelocityVector() + new Vector(0, -GravityConstant) * time) / (1 + k * velocity.GetSpeed() * time)); // Update the velocity by adding the total acceleration to the current speed, keeping the same direction for simplicity
        }
    }
}