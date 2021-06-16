using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace animalConsoleApp
{
    class Animal
    {
        private string especie;
        private string cor;

        private string porte;

        public Animal (string especie, string cor, string porte) {
            this.especie = especie;
            this.cor = cor;
            this.porte = porte;
        }

        public override string ToString() {
            string obj = $"Parabéns tem um {this.especie} da cor {this.cor} com porte {this.porte}!";
            return obj;
        }

        static public List <Animal> animalList = new List<Animal>();

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo/a. Esta aplicação irá imprimir os detalhes de um animal introduzido à sua escolha.");
            // Create a tuple with 3 items: Item1 = Especie, Item2 = Cor, Item3 = Porte.
            var tuple = HelperFunction.getAnimalDetails();
            Animal newAnimal = new Animal(tuple.Item1, tuple.Item2, tuple.Item3);
            Console.WriteLine(newAnimal.ToString());
            animalList.Add(newAnimal);
        }
    }

    static class HelperFunction {

        // Runs getSpecies(), getColor() & getSize() and returns values in a Tuple.
        public static Tuple<string,string,string> getAnimalDetails() {
            string especie = HelperFunction.getSpecies();
            string cor = HelperFunction.getColor();
            string porte = HelperFunction.getSize();
            return new Tuple <string, string, string>(especie, cor, porte);
        }
        
        // Prompt user for the "especie" of the animal
        public static string getSpecies() {
            Console.WriteLine("Por favor, introduza a espécie do animal: ");
            string especie = Console.ReadLine();
            // validate input
            if (especie != null && especie != "" && stringOnlyContainsAlphabeticalChars(especie)) {
                return especie;
            }
            else {
                return getSpecies();
            }
        }    
        
        // Prompt user for the "color" of the animal
        public static string getColor() {
            Console.WriteLine("Por favor, introduza a cor do animal: ");
            string cor = Console.ReadLine(); 
            // validate input
            if (cor != null && cor != "" && stringOnlyContainsAlphabeticalChars(cor)) {
                return cor;
            }
            else {
                return getColor();
            }
        }    
        
        // Prompt user for the 'weight' of the animal, return 'porte'
        public static string getSize() {
            Console.WriteLine("Por favor, introduza o peso do animal (em kg): ");
            string inputString = Console.ReadLine();
            if (inputString != null && inputString != "" && inputString != "0" && stringOnlyContainsNumbers(inputString)) {
                float peso = float.Parse(inputString);
                string porte = calculateSize(peso);
                return porte;
            }
            else {
                return getSize();
            }
        }

        // Calculate 'porte' of animal based on their weight
        public static string calculateSize(float peso) {
            string porte;
            if(peso > 0 && peso < 5) {
                porte = "pequeno";
                return porte;
            }
            
            else if (peso >= 5 && peso <= 15) {
                porte = "médio";
                return porte;
            }
            
            else if (peso > 15) {
                porte = "grande";
                return porte;
            }

            else {
                porte = "ERROR";
                return porte;
            }
        }

        // Validate Input - Check if string only has alphabetic characters.
        public static Boolean stringOnlyContainsAlphabeticalChars(string stringToValidate) {
            for (var i = 0; i < stringToValidate.Length; i++) {
                var currentChar = stringToValidate[i];
                if (!char.IsLetter(currentChar) && !char.IsSeparator(currentChar)) {
                    Console.WriteLine("\n --- INVÁLIDO: Não são aceites números ou simbolos! ---");
                    return false;
                }  
            }
            return true;
        }

        public static Boolean stringOnlyContainsNumbers(string stringToValidate) {
            Regex rx = new Regex(@"^([0-9][0-9]*)(\.[1-9]+)?$");
            if (rx.IsMatch(stringToValidate)) {
                return true;
            }  
            Console.WriteLine("\n --- INVÁLIDO: Insira um número positivo arrendodado às unidades ou décimas ---");
            return false;
        }

        // Print all animals in List
        public static void printAllAnimals() {
            foreach( Animal animal in Animal.animalList) {
                    Console.WriteLine(animal.ToString());
                }
        }

    }

}