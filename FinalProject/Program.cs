using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FinalProject
{
        class Program
    {
        static void Main(string[] args)
        {
            var drugs = new Drugs();
            var diseases = new Diseases();
            System.Console.WriteLine("Read the files : (R)");
            while(Console.ReadLine() != "R")
                System.Console.WriteLine("Please insert (R) to start the app");
            drugs.ReadFiles(drugs,diseases);
            System.Console.WriteLine(@"1 . Add to Dataset
2 . Delete From Dataset
3 . Search in Dataset
4 . Buy Drugs (total price)
5 . Show the Effects in your priscription
6 . Show alergies in your priscription
7 . Inflation for drugs' prices (%)
0 . Quit the program
(Enter the number)");
            var numberOfFunc = 0;
            var function = Console.ReadLine();
            while(function == "" && !int.TryParse(function, out numberOfFunc) && (int.Parse(function) > 7 && int.Parse(function) < 1))
            {
                System.Console.WriteLine("Invalid Input (empty input or non-integer or unavailable function(1 to 7)  )");
                function = Console.ReadLine();
            }
            if (function == "1")
            {
                System.Console.WriteLine(@"1 . Add Drug
2 . Add Disease");
                function = Console.ReadLine();
                while(function == "" && !int.TryParse(function, out numberOfFunc) && (int.Parse(function) > 2 && int.Parse(function) < 1))
                {
                    System.Console.WriteLine("Invalid Input (empty input or non-integer or unavailable function(1 to 7)  )");
                    function = Console.ReadLine();
                }
                if(function == "1")
                {
                    var checkInput = 0;
                    float checkedPrice = 0;
                    System.Console.Write("Drug's Name : ");
                    string newDrug = Console.ReadLine();
                    while(newDrug == "" && int.TryParse(newDrug, out checkInput))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer)");
                        newDrug = Console.ReadLine();
                    }
                    System.Console.Write("Drug's Price : ");
                    string newPrice = Console.ReadLine();
                    while(newPrice == "" && !float.TryParse(newPrice, out checkedPrice))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or non-integer)");
                        newPrice = Console.ReadLine();
                    }
                    drugs.AddDrug(newDrug, float.Parse(newPrice),diseases.key);
                    System.Console.WriteLine("----------------------");
                    drugs.DrugsInfo(newDrug);
                }
                if(function == "2")
                {
                    var checkInput = 0;
                    System.Console.Write("Disease's Name : ");
                    string newDisease = Console.ReadLine();
                    while(newDisease == "" && int.TryParse(newDisease, out checkInput))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer)");
                        newDisease = Console.ReadLine();
                    }
                    diseases.AddDisease(newDisease,drugs.key);
                    System.Console.WriteLine("----------------------");
                    diseases.MedicalAdvice(newDisease);
                }
            }
            else if (function == "2")
            {
                System.Console.WriteLine(@"1 . Delete Drug
2 . Delete Disease");
                function = Console.ReadLine();
                while(function == "" && !int.TryParse(function, out numberOfFunc) && (int.Parse(function) > 2 && int.Parse(function) < 1))
                {
                    System.Console.WriteLine("Invalid Input (empty input or non-integer or unavailable function(1 to 7)  )");
                    function = Console.ReadLine();
                }
                if(function == "1")
                {
                    var checkInput = 0;
                    System.Console.Write("Drug's Name : ");
                    string nameDrug = Console.ReadLine();
                    while(nameDrug == "" && int.TryParse(nameDrug, out checkInput))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer)");
                        nameDrug = Console.ReadLine();
                    }
                    drugs.DeleteDrug(nameDrug,diseases);
                }
                if(function == "2")
                {
                    var checkInput = 0;
                    System.Console.Write("Disease's Name : ");
                    string newDisease = Console.ReadLine();
                    while(newDisease == "" && int.TryParse(newDisease, out checkInput))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer)");
                        newDisease = Console.ReadLine();
                    }
                    diseases.DeleteDisease(newDisease,drugs);
                }
            }
            else if(function == "3")
            {System.Console.WriteLine(@"1 . Search Drug
2 . Search Disease");
                function = Console.ReadLine();
                while(function == "" && !int.TryParse(function, out numberOfFunc) && (int.Parse(function) > 2 && int.Parse(function) < 1))
                {
                    System.Console.WriteLine("Invalid Input (empty input or non-integer or unavailable function(1 to 7)  )");
                    function = Console.ReadLine();
                }
                if(function == "1")
                {
                    var checkInput = 0;
                    System.Console.Write("Drug's Name : ");
                    string nameDrug = Console.ReadLine();
                    while(nameDrug == "" && int.TryParse(nameDrug, out checkInput))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer)");
                        nameDrug = Console.ReadLine();
                    }
                    if(drugs.key.ContainsKey(nameDrug))
                        drugs.DrugsInfo(nameDrug);
                    else
                        System.Console.WriteLine("This drug is not available");
                }
                if(function == "2")
                {
                    var checkInput = 0;
                    System.Console.Write("Disease's Name : ");
                    string newDisease = Console.ReadLine();
                    while(newDisease == "" && int.TryParse(newDisease, out checkInput))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer)");
                        newDisease = Console.ReadLine();
                    }
                    if(diseases.key.ContainsKey(newDisease))
                        diseases.MedicalAdvice(newDisease);
                    else
                        System.Console.WriteLine("This disease is not available");
                }
            }
            else if(function == "4")
            {
                List<Drug> listOfDrug = new List<Drug>();
                System.Console.Write("Number of Drugs? ");
                var numberOfDrugsString = Console.ReadLine();
                var numberOfDrugsInt = int.Parse(numberOfDrugsString);
                float totalPrice = 0;
                for(var i = 0 ; i < numberOfDrugsInt ; i++)
                {
                    var checkInput = 0;
                    Console.Write($"Drug's name (number {i+1}) ? ");
                    var nameDrug = Console.ReadLine();
                    while(nameDrug == "" && int.TryParse(nameDrug, out checkInput) && !drugs.key.ContainsKey(nameDrug))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer or unavailable drug)");
                        nameDrug = Console.ReadLine();
                    }
                    listOfDrug.Add(drugs.key[nameDrug]);
                    totalPrice += drugs.key[nameDrug].Price;
                }
                System.Console.WriteLine("----------------------");
                foreach(var l in listOfDrug)
                    System.Console.WriteLine($"{l.Name} : {l.Price}");
                System.Console.WriteLine($"Total price = {totalPrice}");
            }
            else if(function == "5")
            {
                List<Drug> listOfDrug = new List<Drug>();
                System.Console.Write("Number of Drugs? ");
                var numberOfDrugsString = Console.ReadLine();
                var numberOfDrugsInt = int.Parse(numberOfDrugsString);
                for(var i = 0 ; i < numberOfDrugsInt ; i++)
                {
                    var checkInput = 0;
                    Console.Write($"Drug's name (number {i+1}) ? ");
                    var nameDrug = Console.ReadLine();
                    while(nameDrug == "" && int.TryParse(nameDrug, out checkInput) && !drugs.key.ContainsKey(nameDrug))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer or unavailable drug)");
                        nameDrug = Console.ReadLine();
                    }
                    listOfDrug.Add(drugs.key[nameDrug]);
                }
                System.Console.WriteLine("----------------------");
                foreach(var l in listOfDrug)
                {
                    System.Console.WriteLine($"{l.Name}");
                    if(l.EffectsList.Count != 0)
                    {
                        System.Console.WriteLine($"Effects of {l.Name} (Effects,Drug)");
                        foreach( var i in l.EffectsList)
                            System.Console.WriteLine($"( {i.Value.Name} ,{i.Value.Drug.Name} )");
                    }
                    else{
                        System.Console.WriteLine($"No Effect for {l.Name}");
                    }
                }
            }
            else if(function == "6")
            {
                List<Drug> listOfDrug = new List<Drug>();
                System.Console.Write("Number of Drugs? ");
                var numberOfDrugsString = Console.ReadLine();
                for(var i = 0 ; i < int.Parse(numberOfDrugsString) ; i++)
                {
                    var checkInput = 0;
                    Console.Write($"Drug's name (number {i+1}) ? ");
                    var nameDrug = Console.ReadLine();
                    while(nameDrug == "" && int.TryParse(nameDrug, out checkInput) && !drugs.key.ContainsKey(nameDrug))
                    {
                        System.Console.WriteLine("Invalid Input (empty input or integer or unavailable drug)");
                        nameDrug = Console.ReadLine();
                    }
                    listOfDrug.Add(drugs.key[nameDrug]);
                }
                System.Console.WriteLine("----------------------");
                foreach(var l in listOfDrug)
                {
                    System.Console.WriteLine($"{l.Name}");
                    if(l.positiveForDiseases.Count != 0)
                    {
                        System.Console.WriteLine($"Positive Effect of {l.Name} (Disease)");
                        foreach( var i in l.positiveForDiseases)
                            System.Console.WriteLine($"[ {i} ]");
                    }
                    if(l.negativeForDiseases.Count != 0)
                    {
                        System.Console.WriteLine($"Negative Effect of {l.Name} (Disease)");
                        foreach( var i in l.negativeForDiseases)
                            System.Console.WriteLine($"[ {i} ]");
                    }
                    if(l.positiveForDiseases.Count == 0)
                        System.Console.WriteLine($"No Positive Effect for {l.Name}");
                    if(l.negativeForDiseases.Count == 0)
                        System.Console.WriteLine($"No Negative Effect for {l.Name}");
                }
            }
            else if(function == "7")
            {
                string inflationPercent = Console.ReadLine();
                drugs.ChangeDrugsPrice(float.Parse(inflationPercent));
            }
            else if(function == "0")
            {
                System.Console.WriteLine("End of the app.");
            }
            drugs.CheckDelOrAdd(diseases);
            diseases.CheckDelOrAdd(drugs);
        }
    }
}