using System;

namespace A3
{
    public class Person
    {
        public readonly string Name;
        public readonly int Age;
        public readonly float Weight;
        public readonly bool IsMan;
        public Person 
            BiggerNameBiggerAgeBiggerWeight, 
            BiggerNameBiggerAgeSmallerWeight, 
            BiggerNameSmallerAgeBiggerWeight, 
            BiggerNameSmallerAgeSmallerWeight, 
            SmallerNameBiggerAgeBiggerWeight, 
            SmallerNameBiggerAgeSmallerWeight, 
            SmallerNameSmallerAgeBiggerWeight, 
            SmallerNameSmallerAgeSmallerWeight;
        public Person(string name, int age, float weight, string gender)
        {
            Name = name;
            Age = age;
            Weight = weight;
            IsMan = gender == "M" ? true : false;
        }
    }

    public class SearchTree
    {
        public void Insert(string name, int age, float weight, string gender)
        {
            if (_proot == null)
                _proot = new Person(name, age, weight, gender);
            else
            {
                var insertNode = _proot;
                while (insertNode != null)
                {
                    insertNode = WhichPerson(name, age, weight, gender, insertNode);    
                }
                insertNode = new Person(name, age, weight, gender);
            }
            Console.WriteLine($"{name} {age} {weight} {gender}");
        }

        public bool Search(string name, int age, float weight, string gender)
        {
            
        }

        private static Person WhichPerson(string name, int age, float weight, string gender, Person somebody)
        {
            if (name[1] < somebody.Name[1] 
                && age < somebody.Age 
                && weight < somebody.Weight)
                return somebody.SmallerNameSmallerAgeSmallerWeight;
            if (name[1] < somebody.Name[1] 
                     && age < somebody.Age 
                     && weight >= somebody.Weight)
                return somebody.SmallerNameSmallerAgeBiggerWeight;
            if (name[1] < somebody.Name[1] 
                && age >= somebody.Age 
                && weight < somebody.Weight)
                return somebody.SmallerNameBiggerAgeSmallerWeight;
            if (name[1] < somebody.Name[1] 
                && age >= somebody.Age 
                && weight >= somebody.Weight)
                return somebody.SmallerNameBiggerAgeBiggerWeight;
            if (age < somebody.Age && weight < somebody.Weight)
                return somebody.BiggerNameSmallerAgeSmallerWeight;
            if (age < somebody.Age && weight >= somebody.Weight)
                return somebody.BiggerNameSmallerAgeBiggerWeight;
            return weight < somebody.Weight ? somebody.BiggerNameBiggerAgeSmallerWeight : 
                somebody.BiggerNameBiggerAgeBiggerWeight;
        }
        private Person _proot;
    }
    internal static class Program
    {
        private static void Main()
        {
        }
    }
}