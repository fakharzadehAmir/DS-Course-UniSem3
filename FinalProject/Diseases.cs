using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FinalProject
{
    internal class Disease
    {
        public string Name;
        public Dictionary<string, Drug> PositiveDrugs = new Dictionary<string, Drug>();
        public Dictionary<string, Drug> NegativeDrugs = new Dictionary<string, Drug>();
    }

    internal class Diseases
    {
        private bool _add = false;
        private bool _del = false;

        public Diseases()
        {
            key = new Dictionary<string, Disease>();
        }

        public Dictionary<string, Disease> key = null;

        public void RandomAdd(string newName, Dictionary<string, Drug> drugs)
        {
            var random = new Random();
            for (var i = 0; i < random.Next(0, 3); i++)
            {
                var aDrugs = drugs.ElementAt(random.Next(drugs.Count - 1)).Value;
                drugs[aDrugs.Name].positiveForDiseases.Add(newName);
                this.key[newName].PositiveDrugs.Add(aDrugs.Name, drugs[aDrugs.Name]);
            }

            for (var i = 0; i < random.Next(1, 4); i++)
            {
                var aDrugs = drugs.ElementAt(random.Next(drugs.Count - 1)).Value;
                drugs[aDrugs.Name].negativeForDiseases.Add(newName);
                this.key[newName].NegativeDrugs.Add(aDrugs.Name, drugs[aDrugs.Name]);
            }
        }

        public void AddDisease(string name, Dictionary<string, Drug> drugs)
        {
            var sw = new Stopwatch();
            sw.Start();
            File.AppendAllText(@"C:\git\DS0001\FinalProject\datasets\diseases.txt",$"Dis_{name}\n");
            this.key[name] = (new Disease {Name = name});
            this.RandomAdd(name, drugs);
            _add = true;
            System.Console.WriteLine("New disease is added !");
            Console.WriteLine($"Add Disease (microSecond) : {sw.ElapsedTicks / 10}");
            File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"New disease ({name}) is added[{DateTime.Now}].\n");
        }

        public void DeleteDisease(string name, Drugs drugs)
        {
            var sw = new Stopwatch();
            sw.Start();
            foreach (var (s, _) in key)
            {
                if (s == name)
                {
                    this.RemoveDiseaseFromDrugs(name, drugs);
                    key.Remove(name);
                    _del = true;
            File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"a disease ({name}) is deleted[{DateTime.Now}].\n");
                    break;
                }
            }

            // }
            if (_del == false)
            {
                System.Console.WriteLine("The disease is unavailable !");
            File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"a disease ({name}) is unavailable[{DateTime.Now}].\n");
            }
            Console.WriteLine($"Delete Disease (microSecond) : {sw.ElapsedTicks / 10}");
            File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"a disease ({name}) is deleted[{DateTime.Now}].\n");
        }

        private void RemoveDiseaseFromDrugs(string diseaseDeletedName, Drugs drugs)
        {
            foreach (var (name, drug) in this.key[diseaseDeletedName].NegativeDrugs)
                drugs.key[name].negativeForDiseases.Remove(diseaseDeletedName);
            foreach (var (name, drug) in this.key[diseaseDeletedName].PositiveDrugs)
                drugs.key[name].positiveForDiseases.Remove(diseaseDeletedName);
        }

        public void DrugsDiseases(string dis, string alergies, Dictionary<string, Drug> drugs)
        {
            //positive for alergies
            key[dis].PositiveDrugs = alergies.Split(" ; ")
                .Where(s => s.Substring(s.IndexOf(',') + 1, 1) == "+")
                .Select(s =>
                {
                    var nameDrug = s.Substring(s.IndexOf('_') + 1, s.IndexOf(',') - s.IndexOf('_') - 1);
                    drugs[nameDrug].positiveForDiseases.Add(dis);
                    return drugs[nameDrug];
                })
                .ToDictionary(de => de.Name);
            //negative for alergies
            key[dis].NegativeDrugs = alergies.Split(" ; ")
                .Where(s => s.Substring(s.IndexOf(',') + 1, 1) == "-")
                .Select(s =>
                {
                    var nameDrug = s.Substring(s.IndexOf('_') + 1, s.IndexOf(',') - s.IndexOf('_') - 1);
                    drugs[nameDrug].negativeForDiseases.Add(dis);
                    return drugs[nameDrug];
                })
                .ToDictionary(de => de.Name);
        }

        public void UpdateDrugsDiseases(string nameOfDrug)
        {
            foreach (var (s, d) in this.key.Where(k
                => k.Value.NegativeDrugs.Count != 0 || k.Value.PositiveDrugs.Count != 0))
            {
                if (d.NegativeDrugs.ContainsKey(nameOfDrug))
                    d.NegativeDrugs.Remove(nameOfDrug);
                else if (d.PositiveDrugs.ContainsKey(nameOfDrug))
                    d.PositiveDrugs.Remove(nameOfDrug);
            }
        }


        public void MedicalAdvice(string nameOfDiseases)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            if (this.key.ContainsKey(nameOfDiseases))
            {
                Console.WriteLine(@$"Medical Advice for Disease ( {nameOfDiseases} ) : ");
                if (this.key[nameOfDiseases].PositiveDrugs.Count != 0)
                {
                    Console.WriteLine("*** you SHOULD use : ");
                    foreach (var (n, d) in this.key[nameOfDiseases].PositiveDrugs)
                        Console.Write($" [ {n} ]");
                    Console.WriteLine();
                }

                if (this.key[nameOfDiseases].NegativeDrugs.Count != 0)
                {
                    Console.WriteLine("*** DO NOT use : ");
                    foreach (var (n, d) in this.key[nameOfDiseases].NegativeDrugs)
                        Console.Write($" [ {n} ]");
                    Console.WriteLine();
                }
            File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"Medical advice for disease ({nameOfDiseases}) is printed[{DateTime.Now}].\n");
            }
            else
            {
                System.Console.WriteLine($"The disease ({nameOfDiseases}) doesn't exist. ");
                File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
                $"The disease ({nameOfDiseases}) doesn't exist [{DateTime.Now}].\n");
            }
            Console.WriteLine($"Medical Advice (microSecond) : {stopwatch.ElapsedTicks / 10}");
        }

        public void CheckDelOrAdd(Drugs drugs)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            if (_add == true || _del == true)
            {
                if(_del == true)
                {
                    using var sw = File.CreateText(@"C:\git\DS0001\FinalProject\datasets\diseases.txt");
                    foreach (var (name, disease) in this.key)
                    {
                        sw.WriteLine($"Dis_{name}");
                    }
                }
                if (!drugs.alergieCheck)
                {
                    using var swa = File.CreateText(@"C:\git\DS0001\FinalProject\datasets\alergies.txt");
                    foreach (var (name, disease) in this.key)
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
                            }
                            swa.WriteLine();
                        }
                }
            }
            Console.WriteLine($"Rewrite Disease File (microSecond) : {stopwatch.ElapsedTicks / 10}");
                File.AppendAllText(@"C:\git\DS0001\FinalProject\log\log.txt",
            $"Data was rewritten to the files [{DateTime.Now}].\n");
        }
    }
}