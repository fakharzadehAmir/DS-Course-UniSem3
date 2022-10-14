using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FinalProject
{
    public class Drug
    {
        public string Name;
        public float  Price;
        public List<string> positiveForDiseases = new List<string>();
        public List<string> negativeForDiseases = new List<string>();
        public Dictionary<string,Effects> EffectsList = new Dictionary<string,Effects>();
    }

    internal class Drugs
    {
        private bool _add = false;
        private bool _del = false;

        public Drugs()
        {
            key = new Dictionary<string, Drug>();
        }
        public void ReadFiles(Drugs drugs, Diseases diseases)
        {
            var sw = new Stopwatch();
            sw.Start();
            foreach (var d in System.IO.File.ReadLines(@"C:\git\DS0001\FinalProject\datasets\drugs.txt"))
                drugs.key[d.Split(" : ")[0].Split("Drug_")[1]] = (new Drug
                    {Name = (d.Split(" : ")[0]).Split("Drug_")[1], Price = float.Parse(d.Split(" : ")[1])});
            foreach (var e in System.IO.File.ReadLines(@"C:\git\DS0001\FinalProject\datasets\effects.txt"))
                drugs.DrugsEffects(e.Split(" : ")[0].Split("Drug_")[1], e.Split(" : ")[1]);
            foreach (var d in System.IO.File.ReadLines(@"C:\git\DS0001\FinalProject\datasets\diseases.txt"))
                diseases.key[d.Split("Dis_")[1]] = new Disease {Name = d.Split("Dis_")[1]};
            foreach (var a in System.IO.File.ReadLines(@"C:\git\DS0001\FinalProject\datasets\alergies.txt"))
                diseases.DrugsDiseases(a.Split(" : ")[0].Split("Dis_")[1],
                    a.Split(" : ")[1], drugs.key);
            Console.WriteLine($"Read Files (microSecond) : {sw.ElapsedTicks / 10}");
            using (StreamWriter swe = new StreamWriter(@"C:\git\DS0001\FinalProject\log\log.txt"))
            swe.Write($"Files were read and data structures were created [{DateTime.Now}].\n");
        }

        public Dictionary<string, Drug> key = null;

        public string GenerateRandomString()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[10];
            var random = new Random();
            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        public void RandomAdd(string newName, Dictionary<string, Disease> diseases)
        {
            var random = new Random();
            //effects
            for (var i = 0; i < random.Next(1, 3); i++)
            {
                var aDrug = this.key.ElementAt(random.Next(this.key.Count - 1)).Value;
                var effect = GenerateRandomString();
                var aEffects = new Effects() {Name = effect, Drug = aDrug};
                this.key[newName].EffectsList.Add(aEffects.Name, aEffects);
                aDrug.EffectsList.Add(aEffects.Name, new Effects() {Name = effect, Drug = this.key[newName]});
            }

            //positive
            for (var i = 0; i < random.Next(0, 3); i++)
            {
                var aDisease = diseases.ElementAt(random.Next(diseases.Count - 1)).Value;
                diseases[aDisease.Name].PositiveDrugs.Add(newName, this.key[newName]);
                this.key[newName].positiveForDiseases.Add(aDisease.Name);
            }

            //negative
            for (var i = 0; i < random.Next(1, 4); i++)
            {
                var aDisease = diseases.ElementAt(random.Next(diseases.Count - 1)).Value;
                diseases[aDisease.Name].NegativeDrugs.Add(newName, this.key[newName]);
                this.key[newName].negativeForDiseases.Add(aDisease.Name);
            }
        }

        public void AddDrug(string name, float price, Dictionary<string, Disease> diseases)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            this.key[name] = (new Drug {Name = name, Price = price});
            File.AppendAllText(@"C:\git\DS0001\FinalProject\datasets\drugs.txt",$"Drug_{name} : {price}\n");
            this.RandomAdd(name, diseases);
            _add = true;
            System.Console.WriteLine("New drug is added !");
            Console.WriteLine($"Add Drug (microSecond) : {stopwatch.ElapsedTicks / 10}");
            File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"New drug ({name}) is added[{DateTime.Now}].\n");
        }

        public void DeleteDrug(string name, Diseases diseases)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            bool available = false;
            foreach (var (s, v) in key)
            {
                if (s == name)
                {
                    diseases.UpdateDrugsDiseases(name);
                    this.UpdateEffects(name);
                    key.Remove(name);
                    _del = true;
                    available = true;
                    File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"a drug ({name}) is deleted[{DateTime.Now}].\n");
                    break;
                }
            }

            if (available == false)
                {
                    System.Console.WriteLine("The drug is unavailable !");
                    File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"a drug ({name}) is unavailable[{DateTime.Now}].\n");
                }
            Console.WriteLine($"Delete Drug (microSecond) : {stopwatch.ElapsedTicks / 10}");

        }

        public void DrugsEffects(string drug, string effects)
        {
            key[drug].EffectsList = effects.Split(" ; ")
                .Select(s => new Effects()
                {
                    Drug = key[s.Substring(s.IndexOf('_') + 1,
                        s.IndexOf(',') - s.IndexOf('_') - 1)],
                    Name = s.Substring(s.IndexOf(",",
                            StringComparison.Ordinal) + 5,
                        s.IndexOf(")", StringComparison.Ordinal) - s.IndexOf(",",
                            StringComparison.Ordinal) - 5)
                }).ToDictionary(s => s.Name);
        }

        private void UpdateEffects(string nameOfDeletedDrug)
        {
            foreach (var (s, value) in this.key[nameOfDeletedDrug].EffectsList)
                this.key[value.Drug.Name].EffectsList.Remove(s);
        }

        public void DrugsInfo(string name)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            if (this.key.ContainsKey(name))
            {
                Console.WriteLine($"Drug ( {name} ) Information : ");
                var drug = this.key[name];
                Console.WriteLine($"Name : {name} , Price : {drug.Price}");
                if (drug.positiveForDiseases.Count != 0)
                {
                    Console.WriteLine($"*** GOOD for (Diseases) : ");
                    foreach (var dp in drug.positiveForDiseases)
                        Console.Write($" [ {dp} ] ");
                    Console.WriteLine();
                }

                if (drug.negativeForDiseases.Count != 0)
                {
                    Console.WriteLine($"*** BAD for (Diseases) : ");
                    foreach (var dn in drug.negativeForDiseases)
                        Console.Write($" [ {dn} ] ");
                    Console.WriteLine();
                }

                if (drug.EffectsList.Count != 0)
                {
                    Console.WriteLine("*** Effects with other drugs [ Effect, Drug ]: ");
                    foreach (var (s, v) in drug.EffectsList)
                        Console.Write($" [ {s} , {v.Drug.Name} ] ");
                    Console.WriteLine();
                }
            File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"Drug's information ({name}) is printed[{DateTime.Now}].\n");
            }
            else
            {
                System.Console.WriteLine($"The drug ({name}) doesn't exist. ");
                File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
                $"The drug ({name}) doesn't exist [{DateTime.Now}].\n");
            }
            Console.WriteLine($"Drug's Information (microSecond) : {stopwatch.ElapsedTicks / 10}");
        }

        public void ChangeDrugsPrice(float percent)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _del = true;
            foreach (var (s, v) in this.key)
                v.Price *= (100 + percent) / 100;
            Console.WriteLine($"Drug's Inflation (microSecond) : {stopwatch.ElapsedTicks / 10}");
            File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"Inflation affected prices [{DateTime.Now}].\n");

        }

        public bool alergieCheck = false;
        public void CheckDelOrAdd(Diseases diseases)
        {
            var sw = new Stopwatch();
            sw.Start();
            if (_add == true || _del == true)
            {
                if(_del == true)
                {
                    using var swr = File.CreateText(@"C:\git\DS0001\FinalProject\datasets\drugs.txt");
                    foreach (var (name, drug) in this.key)
                    {
                        swr.WriteLine($"Drug_{name} : {drug.Price}");
                    }
                }
                using var swe = File.CreateText(@"C:\git\DS0001\FinalProject\datasets\effects.txt");
                foreach (var (name, drug) in this.key)
                    if (drug.EffectsList.Count != 0)
                    {
                        swe.Write($"Drug_{name} :");
                        for (var i = 0; i < drug.EffectsList.Count; i++)
                        {
                            if (i == drug.EffectsList.Count - 1)
                                swe.Write(
                                    $" (Drug_{drug.EffectsList.ElementAt(i).Value.Drug.Name},Eff_{drug.EffectsList.ElementAt(i).Key})");
                            else
                                swe.Write(
                                    $" (Drug_{drug.EffectsList.ElementAt(i).Value.Drug.Name},Eff_{drug.EffectsList.ElementAt(i).Key}) ;");
                        }
                        swe.WriteLine();
                    }
                using var swa = File.CreateText(@"C:\git\DS0001\FinalProject\datasets\alergies.txt");
                foreach (var (name, disease) in diseases.key)
                    if (disease.NegativeDrugs.Count != 0
                        || disease.PositiveDrugs.Count != 0)
                    {
                        swa.Write($"Dis_{name} :");
                        if (disease.NegativeDrugs.Count != 0)
                        {
                            for (var i = 0; i < disease.NegativeDrugs.Count; i++)
                            {
                                if (i == disease.NegativeDrugs.Count - 1 && disease.PositiveDrugs.Count == 0)
                                    swa.WriteLine($" (Drug_{disease.NegativeDrugs.ElementAt(i).Value.Name},-)");
                                else 
                                    swa.Write($" (Drug_{disease.NegativeDrugs.ElementAt(i).Value.Name},-) ;");
                            }
                        }

                        if (disease.PositiveDrugs.Count != 0)
                        {
                            for (var i = 0; i < disease.PositiveDrugs.Count; i++)
                            {
                                if (i == disease.PositiveDrugs.Count - 1)
                                    swa.Write($" (Drug_{disease.PositiveDrugs.ElementAt(i).Value.Name},+)");
                                else
                                    swa.Write($" (Drug_{disease.PositiveDrugs.ElementAt(i).Value.Name},+) ;");
                            }
                            swa.WriteLine();
                        }
                        alergieCheck = true;
                    }
            }
                Console.WriteLine($"Rewrite Drugs File (microSecond) : {sw.ElapsedTicks / 10}");
                File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"Data was rewritten to the files [{DateTime.Now}].\n");
        } 
    }
}