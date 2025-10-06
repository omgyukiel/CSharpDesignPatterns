﻿using System.Text;

namespace BuilderPattern
{
    /// Product
    /// 
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string part in _parts)
            {
                sb.Append($"Car Type: {_carType}, Part: {part}");
            }

            return sb.ToString();
        }
    }

    /// Builder
    /// 
    public abstract class CarBuilder
    {
        public Car Car { get; private set; }

        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();
    }

    /// <summary>
    /// ConcreateBuilder1 class
    /// </summary>
    ///
    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder() : base("Mini")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'not a v8'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'3 doors with stripes'");
        }
    }

    // <summary>
    /// ConcreateBuilder2 class
    /// </summary>
    ///
    public class MustangBuilder: CarBuilder
    {
        public MustangBuilder() : base("Mustang")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'a v8'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'4 doors with flames'");
        }
    }


    /// Director
    /// 
    public class Garage
    {
        private CarBuilder? _builder;

        public Garage()
        {
        }

        public void Construct(CarBuilder builder)
        {
            _builder = builder;
            _builder.BuildEngine();
            _builder.BuildFrame();
        }

        public void Show()
        {
            Console.WriteLine(_builder?.Car.ToString());
        }
    }
}
