using Microsoft.VisualBasic;

namespace AdvMath
{
    public class PhysObject
    {
        public Vector Position { get; set; } // Position of the object in 2D space, can be updated as the object moves
        public Velocity Velocity { get; private set;} // Velocity is read-only to ensure it can only be modified through methods that apply forces or update the object
        public double Mass { get; set; } // Mass of the object, can be used for more complex physics calculations
        private double DragCoefficient { get; set; } // Optional property to simulate air resistance or drag, can be used in future enhancements 
        private string Shape { get; set; } // Optional property to represent the shape of the object, can be used for collision detection or visualization
        public string Name { get; set; } // Optional property to give the object a name for easier identification in debugging or visualization
        private double Area { get; set; } // Optional property to represent the cross-sectional area of the object, can be used for more accurate drag calculations in future enhancements
        private double DragConstant { get; set; } // Optional property to represent a custom drag constant, can be used for more complex drag calculations in future enhancements

        public PhysObject() // Default constructor initializes position to (0,0) and velocity to zero
        {
            Position = new Vector(0, 0);
            Velocity = new Velocity();
            Mass = 1; // Default mass is 1 unit, can be modified as needed
            Name = "Unnamed Object"; // Default name for the object
            Shape = "Cube"; // Default shape is a cube
            Area = 0.1; // Default area is 1 unit, can be modified as needed
            ApplyDragCoef(); // Automatically apply the default drag coefficient when the object is initialized, can be modified later if needed
            ApplyDragConstant(); // Automatically set the drag constant based on the default shape when the object is initialized, can be modified later if needed
        }

        public PhysObject(Vector position) // Constructor to initialize only the position, velocity defaults to zero
        {
            Position = position;
            Velocity = new Velocity();
            Mass = 1; // Default mass is 1 unit, can be modified as needed
            Name = "Unnamed Object"; // Default name for the object
            Shape = "Cube"; // Default shape is a cube
            Area = 0.1; // Default area is 1 unit, can be modified as needed
            ApplyDragCoef(); // Automatically apply the default drag coefficient when position is initialized, can be modified later if needed
            ApplyDragConstant(); // Automatically set the drag constant based on the default shape when position is initialized
        }
        public PhysObject(Vector position, double mass) // Constructor to initialize position and mass, velocity defaults to zero
        {
            Position = position;
            Velocity = new Velocity();
            Mass = mass; // Set mass based on the provided parameter
            Name = "Unnamed Object"; // Default name for the object
            Shape = "Cube"; // Default shape is a cube
            Area = 0.1; // Default area is 1 unit, can be modified as needed
            ApplyDragCoef(); // Automatically apply the default drag coefficient when mass is initialized, can be modified later if needed
            ApplyDragConstant(); // Automatically set the drag constant based on the mass and default shape when mass is initialized, can be modified later if needed
        }
        public PhysObject(Vector position, String shape) // Constructor to initialize position and shape, velocity and mass default to zero
        {
            Position = position;
            Velocity = new Velocity();
            Mass = 1; // Default mass is 1 unit, can be modified as needed
            Name = "Unnamed Object"; // Default name for the object
            Shape = shape; // Set the shape based on the provided parameter
            ApplyDragCoef(); // Automatically set the drag coefficient based on the shape when the shape is initialized
            ApplyDragConstant(); // Automatically set the drag constant based on the shape when the shape is initialized
        }

        public void SetName(String name) // Method to set the name of the object, useful for debugging or visualization purposes
        {
            Name = name;
        }

        public void SetShape(String shape) // Method to set the shape of the object, which can be used for collision detection or visualization
        {
            Shape = shape;
            ApplyDragCoef(); // Automatically apply the corresponding drag coefficient when the shape is set
            ApplyDragConstant(); // Automatically set the drag constant based on the new shape
        }

        public void SetArea(double area) // Method to set the cross-sectional area of the object, which can be used for more accurate drag calculations
        {
            Area = area;
            ApplyDragConstant(); // Automatically update the drag constant based on the new area
        }

        private void ApplyDragConstant() // Method to set a custom drag constant, allowing for more flexibility in simulations
        {
            DragConstant = TransPhysics.AirDensity * DragCoefficient * Area / (2 * Mass); // Example calculation for a custom drag constant based on the drag coefficient and area, can be modified for more complex simulations
        }

        public void ApplyDragCoef() // Method to set the drag coefficient based on the shape of the object, can be expanded with more shapes and corresponding coefficients
        {
            switch (Shape)
            {
                case "Sphere":
                    DragCoefficient = 0.47; // Drag coefficient for a sphere
                    Area = Math.PI * Math.Pow(0.5, 2); // Assuming a radius of 0.5 units for the sphere to calculate the cross-sectional area
                    break;
                case "Cube":
                    DragCoefficient = 1.05; // Drag coefficient for a cube
                    Area = 1.0; // Assuming a cross-sectional area of 1 unit for the cube
                    break;
                case "Cylinder":
                    DragCoefficient = 0.82; // Drag coefficient for a cylinder
                    Area = Math.PI * Math.Pow(0.5, 2); // Assuming a radius of 0.5 units for the cylinder to calculate the cross-sectional area
                    break;
                default:
                    DragCoefficient = 1.0; // Default drag coefficient for unknown shapes
                    Area = 0.1; // Default area for unknown shapes
                    break;
            }
        }
        public void ApplyDragCoef(double customDrag) // Method to set a custom drag coefficient, allowing for more flexibility in simulations
        {
            DragCoefficient = customDrag;
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
            Velocity = TransPhysics.ApplyPhysics(Velocity, DragConstant, time); // Apply physics to the velocity before moving the object
            Position = TransPhysics.Move(Position, Velocity, time); // Move the object while applying physics to its velocity
        }

        public override string ToString() // Override ToString for easy debugging and visualization of the object's state
        {
            return $"{Name}: Position: {Position}  \t Velocity: ({Velocity})  \t Mass: {Mass:F4}";
        }

        public void ConsoleWrite() // Method to print the current state of the object to the console
        {
            Console.WriteLine($"{this}");
        }

        public double GetDragCoefficient() // Method to retrieve the current drag coefficient, useful for debugging or advanced physics calculations
        {
            return DragCoefficient;
        }

        public String GetShape() // Method to retrieve the shape of the object, useful for debugging or visualization purposes
        {
            return Shape;
        }
    }
}