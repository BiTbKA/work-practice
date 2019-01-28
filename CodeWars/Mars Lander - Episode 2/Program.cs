using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        var marsLander = new MarsLander();
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        int prevYvalue = 0, prevXvalue = 0;
        var land = new List<Point>();
        for (int i = 0; i < surfaceN; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
            land.Add(new Point(landX, landY));

            if (i != 0 && landY == prevYvalue)
            {
                FlatGround.Start = new Point(prevXvalue, prevYvalue);
                FlatGround.End = new Point(landX, landY);
                FlatGround.InitializeCenter();
            }
            prevXvalue = landX;
            prevYvalue = landY;
        }


        // game loop
        while (true)
        {
            marsLander.UpdateInfo(Console.ReadLine().Split(' '));

            var rotate = marsLander.GetRotateToFlatGround();
            var power = marsLander.GetPowerToFlatGround(rotate);
            Console.WriteLine(
                string.Format("{0} {1}", rotate, power)
            );

            Console.Error.WriteLine(String.Format("Distance to flat: {0}", marsLander.DistanceToFlatGround()));
            Console.Error.WriteLine(String.Format("RouteIndex to flat: {0}", marsLander.RouteIndex(marsLander.Position)));

        }
    }
}

public class Point
{
    public virtual int X { get; set; }
    public virtual int Y { get; set; }

    public Point() { }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public double DistanceTo(Point target)
    {
        return Math.Sqrt(Math.Pow(target.X - this.X, 2) + Math.Pow(target.Y - this.Y, 2));
    }
}

#region MarsLander

public class MarsLander
{
    public Point StartPosition { get; set; }

    public Point Position { get; set; }

    public int HorizontalSpeed { get; set; }

    public int VerticalSpeed { get; set; }

    public int Fuel { get; set; }

    public int Rotate { get; set; }

    public int Power { get; set; }

    public void UpdateInfo(string[] inputs)
    {
        this.Position = new Point(int.Parse(inputs[0]), int.Parse(inputs[1]));
        this.HorizontalSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
        this.VerticalSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
        this.Fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
        this.Rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
        this.Power = int.Parse(inputs[6]); // the thrust power (0 to 4).

        if (this.StartPosition == null)
        {
            this.StartPosition = new Point(int.Parse(inputs[0]), int.Parse(inputs[1]));
        }
    }

    public double DistanceToFlatGround()
    {
        return this.Position.DistanceTo(FlatGround.Center);
    }

    public int GetRotateToFlatGround()
    {

        int result = this.Rotate;
        result -= (RouteIndex(Position) / 10);
        result = GetRotateForLessSpeed(result);

        
            

        if (this.DistanceToFlatGround() > 800 || this.HorizontalSpeed > 20)
            return GetValueInRange(result, -90, 90);

        return 0;
    }

    public int GetPowerToFlatGround(int rotate)
    {
        int power = 3;

        if (DistanceToFlatGround() < 3500)
        {
            if (RouteIndex(Position) > 0)
                power++;
            else if (RouteIndex(Position) < 0)
                power--;
        }

        if (RouteIndex(Position) < 0)
            power++;
        else
            power--;

        if (VerticalSpeed < -20)
            power = 4;

        return GetValueInRange(power, 0, 4);
    }

    public int RouteIndex(Point target)
    {
        var A = FlatGround.Center.Y - StartPosition.Y;
        var B = StartPosition.X - FlatGround.Center.X;
        var C = StartPosition.X * (StartPosition.Y - FlatGround.Center.Y) + StartPosition.Y * (FlatGround.Center.X - StartPosition.X);

        //Console.Error.WriteLine(String.Format("StartPosition.X: {0}", StartPosition.X));
        //Console.Error.WriteLine(String.Format("StartPosition.Y: {0}", StartPosition.Y));
        //Console.Error.WriteLine(String.Format("FlatGround.Center.X: {0}", FlatGround.Center.X));
        //Console.Error.WriteLine(String.Format("FlatGround.Center.Y: {0}", FlatGround.Center.Y));
        //Console.Error.WriteLine(String.Format("A: {0}", A));
        //Console.Error.WriteLine(String.Format("B: {0}", B));
        //Console.Error.WriteLine(String.Format("C: {0}", C));

        //Console.Error.WriteLine(String.Format("target.X: {0}", target.X));
        //Console.Error.WriteLine(String.Format("target.Y: {0}", target.Y));

        return (int)Math.Abs(((A * target.X + B * target.Y + C) / Math.Sqrt(A * A + B * B)));
        //return (Position.X - StartPosition.X) * (FlatGround.Center.Y - StartPosition.Y)
        //    - (FlatGround.Center.X - StartPosition.X) * (Position.Y - StartPosition.Y);
    }

    protected int GetRotateForLessSpeed(int currentRotate)
    {
        var absVerticalSpeed = Math.Abs(this.VerticalSpeed);
        var absHorSpeed = Math.Abs(this.HorizontalSpeed);

        if (absHorSpeed < 20 && absVerticalSpeed < 40)
            return currentRotate;

        currentRotate = GetValueInRange(this.HorizontalSpeed, -60, 60);

        if (absVerticalSpeed > 40)
        {
            var k = absVerticalSpeed;
            if (currentRotate > 0)
                currentRotate -= k;
            else currentRotate += k;
        }

        return currentRotate;
    }

    protected int GetValueInRange(int value, int min, int max)
    {

        if (value > max)
            return max;

        if (value < min)
            return min;

        return value;
    }
}

#endregion

#region FlatGround
static class FlatGround
{
    public static Point Center { get; set; }

    public static Point Start { get; set; }

    public static Point End { get; set; }

    static FlatGround()
    {
        Start = new Point();
        End = new Point();
        Center = new Point();
    }

    public static void InitializeCenter()
    {
        Center.X = (End.X + Start.X) / 2;
        Center.Y = (End.Y + Start.Y) / 2;
    }
}
#endregion