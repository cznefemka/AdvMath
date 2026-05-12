namespace AdvMath
{
    public class PhysObject
    {
        public Vector Position { get; set; } // Position of the object in 2D space, can be updated as the object moves
        public Velocity Velocity { get; private set;} // Velocity is read-only to ensure it can only be modified through methods that apply forces or update the object

        public double Mass { get; set; } // Mass of the object, can be used for more complex physics calculations

        public PhysObject() // Default constructor initializes position to (0,0) and velocity to zero
        {
            Position = new Vector(0, 0);
            Velocity = new Velocity();
            Mass = 1; // Default mass is 1 unit, can be modified as needed
        }

        public PhysObject(Vector position) // Constructor to initialize only the position, velocity defaults to zero
        {
            Position = position;
            Velocity = new Velocity();
            Mass = 1; // Default mass is 1 unit, can be modified as needed
        }
        public PhysObject(Vector position, double mass) // Constructor to initialize position and mass, velocity defaults to zero
        {
            Position = position;
            Velocity = new Velocity();
            Mass = mass; // Set mass based on the provided parameter
        }

         public void ApplyForce(Vector force) // Apply a force to the object, changing its velocity based on the force and time
        {
            Vector acceleration = new Vector(force.X / Mass, force.Y / Mass); // Calculate acceleration using Newton's second law (F = ma)
            Velocity = new Velocity(Velocity.Direction + force.Normalize() * acceleration.Length()); // Update velocity by adding the acceleration to the current speed, keeping the same direction for simplicity
        }
        public void ApplyForce(Vector force, double scale) // Apply a force to the object, changing its velocity based on the force and time
        {
            Vector acceleration = new Vector(force.X / Mass, force.Y / Mass); // Calculate acceleration using Newton's second law (F = ma)
            Velocity = new Velocity(Velocity.Direction + force.Normalize() * scale * acceleration.Length()); // Update velocity by adding the acceleration to the current speed, keeping the same direction for simplicity
        }

        public void Update(double time) // Update the object's position based on its velocity and the elapsed time, applying gravity
        {
            Velocity = TransPhysics.ApplyGravity(Velocity, time); // Apply gravity to the velocity before moving the object
            Position = TransPhysics.Move(Position, Velocity, time); // Move the object while applying gravity to its velocity
        }

        public override string ToString() // Override ToString for easy debugging and visualization of the object's state
        {
            return $"Position: {Position}, Velocity: ({Velocity}), Mass: {Mass}";
        }

        public void ConsoleWrite() // Method to print the current state of the object to the console
        {
            Console.WriteLine($"{this}");
        }
    }
}