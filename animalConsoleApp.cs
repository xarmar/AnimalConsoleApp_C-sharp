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
            string obj = $"\nParabéns tem um {this.especie} da cor {this.cor} com porte {this.porte}!";
            return obj;
        }

        static public List <Animal> animalList = new List<Animal>();

        public static void mainProgram() {
            // Create a tuple with 3 items: Item1 = Especie, Item2 = Cor, Item3 = Porte.
            var tuple = HelperFunction.getAnimalDetails();
            Animal newAnimal = new Animal(tuple.Item1, tuple.Item2, tuple.Item3);
            animalList.Add(newAnimal);
            Console.WriteLine(newAnimal.ToString());
            HelperFunction.giveUserOptions();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo/a. Esta aplicação irá imprimir os detalhes de um animal introduzido à sua escolha.");
            mainProgram();
        }
    }

    static class HelperFunction {

        // Runs getSpecies(), getColor() & getSize() and returns values in a Tuple.
        public static Tuple<string,string,string> getAnimalDetails() {
            string especie = getSpecies();
            string cor = getColor();
            string porte = getSize();
            return new Tuple <string, string, string>(especie, cor, porte);
        }
        
        // Prompt user for the "especie" of the animal
        public static string getSpecies() {
            Console.WriteLine("\n-> Por favor, introduza a espécie do animal: ");
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
            Console.WriteLine("-> Por favor, introduza a cor do animal: ");
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
            Console.WriteLine("-> Por favor, introduza o peso do animal (em kg): ");
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

        // Validate user input - Check if string only has alphabetic characters.
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

        // Validate user input - Check if string only has numbers.
        public static Boolean stringOnlyContainsNumbers(string stringToValidate) {
            Regex rx = new Regex(@"^([0-9][0-9]*)(\.[1-9]+)?$");
            if (rx.IsMatch(stringToValidate)) {
                return true;
            }  
            Console.WriteLine("\n --- INVÁLIDO: Insira um número positivo arrendodado às unidades ou décimas ---");
            return false;
        }

        // program loop
        public static void giveUserOptions() {
            printIntructions();
            ConsoleKeyInfo keyInfo;
            do {
                keyInfo = Console.ReadKey();
            } while (!userPressedOneOfTheOptions(keyInfo));
            }

        public static void printIntructions () {
            Console.WriteLine("\n Escolha uma opção (pressione no seu teclado):");
            Console.WriteLine("   1. Adicionar outro animal. ");
            Console.WriteLine("   2. Ver animais adicionados. ");
            Console.WriteLine("   3. Sair do programa. "); 
        }

        public static bool userPressedOneOfTheOptions (ConsoleKeyInfo keyInfo) {
            if (keyInfo.Key == ConsoleKey.D1) {
                Animal.mainProgram();
                return true;
            }
            if (keyInfo.Key == ConsoleKey.D2) {
                printAllAnimals();
                giveUserOptions();
                return true;
            }
            if (keyInfo.Key == ConsoleKey.D3) {
                return true;
            }

            else {
                Console.WriteLine("\n ---------- INVÁLIDO ----------");
                printIntructions();
                return false;
            }
        }

        // Print all animals in List
        public static void printAllAnimals() {
            Console.WriteLine("\n Aqui estão os seus animais previamente adicionados:");

            foreach( Animal animal in Animal.animalList) {
                    Console.WriteLine(animal.ToString());
                }
        }

    }

}