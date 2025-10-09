using System;

class ThreeD
{
    int x, y, z; 

    public ThreeD() { x = y = z = 0; }
    public ThreeD(int i, int j, int k) { x = i; y = j; z = k; }

    public static ThreeD operator +(ThreeD opl, ThreeD op2)
    {
        return new ThreeD(opl.x + op2.x, opl.y + op2.y, opl.z + op2.z);
    }

    public static ThreeD operator -(ThreeD opl, ThreeD op2)
    {
        return new ThreeD(opl.x - op2.x, opl.y - op2.y, opl.z - op2.z);
    }

    public static bool operator !=(ThreeD a, ThreeD b)
    {
        return a.x != b.x || a.y != b.y || a.z != b.z;
    }

    public static bool operator ==(ThreeD a, ThreeD b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }

    public static ThreeD operator --(ThreeD a)
    {
        return new ThreeD(a.x - 1, a.y - 1, a.z - 1);
    }

    public void Show() => Console.WriteLine($"{x}, {y}, {z}");

    public override bool Equals(object obj)
    {
        if (obj is ThreeD other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return (x, y, z).GetHashCode();
    }
}

class ThreeDDemo
{
    static void Main()
    {
        ThreeD a = new ThreeD(1, 2, 3);
        ThreeD b = new ThreeD(10, 10, 10);
        ThreeD c;

        Console.Write("Координати точки a: ");
        a.Show();
        Console.Write("Координати точки b: ");
        b.Show();

        c = a + b;
        Console.Write("Результат складання a + b: ");
        c.Show();

        c = c - a;
        Console.Write("Результат віднімання c - a: ");
        c.Show();

        Console.WriteLine($"a != b? { (a != b) }");
        Console.WriteLine($"a != a? { (a != a) }");

        Console.WriteLine("Застосування унарного оператора -- до a:");
        a = --a;
        a.Show();

        Console.ReadKey();
    }
}
