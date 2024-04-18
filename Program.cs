IAngle angle = new Angle(270, 0);
Angle angle2 = new Angle(90, 10);
bool exit = false;
while (!exit)
{
    Console.WriteLine("Меню:");
    Console.WriteLine("1. Вывести углы в радианах");
    Console.WriteLine("2. Увеличить угол");
    Console.WriteLine("3. Уменьшить угол");
    Console.WriteLine("4. Вычислить синус угла");
    Console.WriteLine("5. Сравнить углы");
    Console.WriteLine("6. Выйти");

    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Угол 1:");
            Console.WriteLine(angle.ToRadians());

            Console.WriteLine("Угол 2:");
            Console.WriteLine(angle2.ToRadians());
            break;
        case 2:
            angle = angle.Increase(angle2);
            Console.WriteLine("Угол увеличен:");
            angle.Print();
            break;
        case 3:
            angle = angle.Decrease(angle2);
            Console.WriteLine("Угол уменьшен:");
            angle.Print();
            break;
        case 4:
            Console.WriteLine("Синус угла:");
            Console.WriteLine(angle.Sin());
            break;
        case 5:
            int comparison = angle.CompareTo(angle2);
            if (comparison == 0)
            {
                Console.WriteLine("Углы равны");
            }
            else if (comparison == 1)
            {
                Console.WriteLine("Угол больше");
            }
            else
            {
                Console.WriteLine("Угол меньше");
            }
            break;
        case 6:
            exit = true;
            break;
        default:
            Console.WriteLine("Неверный выбор");
            break;
    }
}

interface IAngle
{
    public double ToRadians();
    public Angle Increase(Angle other);
    public Angle Decrease(Angle other);
    public double Sin();
    public int CompareTo(Angle other);
    public void Print();
}
abstract class absAngle : IAngle
{
    protected double degrees;
    protected double minutes;
    public abstract double ToRadians();
    public abstract Angle Increase(Angle other);
    public abstract Angle Decrease(Angle other);
    public abstract double Sin();
    public abstract int CompareTo(Angle other);
    public abstract void Print();
}
class Angle : absAngle
{
    public Angle(double deg, double min)
    {
        degrees = deg % 360;
        if (min > 59)
        {
            degrees += Math.Floor(minutes / 60);
            minutes = min % 60;
        }
        else
        {
            minutes = min;
        }
    }
    public override double ToRadians()
    {
        return (degrees + minutes / 60) * Math.PI / 180;
    }
    public override Angle Increase(Angle other)
    {
        degrees += other.degrees;
        minutes += other.minutes;
        degrees += Math.Floor(minutes / 60);
        minutes = minutes % 60;
        return this;
    }
    public override Angle Decrease(Angle other)
    {
        degrees -= other.degrees;
        minutes -= other.minutes;
        while (minutes < 0)
        {
            minutes += 60;
            degrees--;
        }
        return this;
    }
    public override double Sin()
    {
        return Math.Sin(ToRadians());
    }
    public override int CompareTo(Angle other)
    {
        if (degrees < other.degrees) return -1;
        else if (degrees == other.degrees)
        {
            if (minutes < other.minutes) return -1;
            else if (minutes == other.minutes) return 0;
            else return 1;
        }
        else return 1;
    }
    public override void Print()
    {
        Console.WriteLine($"{degrees}°{minutes}'");
    }
}