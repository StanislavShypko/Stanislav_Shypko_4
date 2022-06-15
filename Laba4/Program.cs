namespace Laba4;

public static class Program {
    public static void Main()
    {
        var dog = new Dog("Бобiк", 15, "Гав-гав");
        Console.WriteLine(dog);
        dog.MakeSound();
        
        var cat = new Cat("Мурчик", 5, "Мяу");
        Console.WriteLine(cat);
        cat.MakeSound();
        
        var parrot = new Parrot("Кєша", 1, "Чiрiк-чiрiк");
        Console.WriteLine(parrot);
        parrot.MakeSound();

        var hata = new Home("Дача");
        hata.AddPet(dog);
        hata.AddPet(cat);
        hata.AddPet(parrot);
        
        // Другий раз
        hata.AddPet(parrot);
        
        // Видалення (бо Бобiк поцарапав диван)
        hata.RemovePet(dog);
    }
}

public class Home
{
    public List<Pet> Pets { get; set; }
    public string Name { get; set; }

    public Home(string name)
    {
        Name = name;
        Pets = new();
    }

    public void AddPet(Pet pet)
    {
        if (Pets.Contains(pet))
        {
            Console.WriteLine("Ця тварина вже є в домi");
            return;
        }
        
        Pets.Add(pet);
        Console.WriteLine($"У домi '{Name}' тепер проживає тварина: {pet}");
    }
    
    public void RemovePet(Pet pet)
    {
        if (!Pets.Contains(pet))
        {
            Console.WriteLine("Такої тварини нема");
            return;
        }
        
        Pets.Remove(pet);
        Console.WriteLine($"З дому '{Name}' вигнали тварину: {pet}");
    }

    public int CountPetsBySound(string sound)
    {
        return Pets.Where(p => p.Sound == sound).Count();
    }
}

public abstract class Pet {
    public string Name { get; set; }
    public double Weight { get; set; }
    public string Sound {get;set;}
    
    protected Pet(string name, double weight, string sound)
    {
        Name = name;
        Weight = weight;
        Sound = sound;
    }

    public void MakeSound()
    {
        Console.WriteLine(Sound);
    }

    public override string ToString()
    {
        return $"{Name}, {Weight}кг";
    }
}

public class Dog : Pet
{
    public Dog(string name, double weight, string sound) : base(name, weight, sound)
    {
    }
    
    public override string ToString()
    {
        return "Пес " + base.ToString();
    }
}

public class Cat : Pet
{
    public Cat(string name, double weight, string sound) : base(name, weight, sound)
    {
    }
    
    public override string ToString()
    {
        return "Кiт " + base.ToString();
    }
}

public abstract class Bird : Pet
{
    public Bird(string name, double weight, string sound) : base(name, weight, sound)
    {
    }
}

public class Parrot : Bird
{
    public Parrot(string name, double weight, string sound) : base(name, weight, sound)
    {
    }
    
    public override string ToString()
    {
        return "Папуга " + base.ToString();
    }
}