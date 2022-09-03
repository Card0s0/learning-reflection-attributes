using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Digite Uma Classe: ");
            var nomeClasse = Console.ReadLine();

            var typeClass = Type.GetType(nomeClasse);
            var methodsClass = typeClass.GetMethods();

            var methodsNotStatics = methodsClass.Where(m => !m.IsStatic).ToList();


            foreach (var method in methodsNotStatics)
            {
                var parameters = method.GetParameters();

                if (parameters.Any())
                {
                    if (!parameters.Any(p => p.ParameterType == typeof(string)))
                    {
                        continue;
                    }
                }

                Console.WriteLine(method.Name);
            }

            Console.WriteLine("Escolha um metodo para executar: ");
            var choosedMethod = Console.ReadLine();

            var choosedMethodClass = typeClass.GetMethod(choosedMethod);
            var parametersFromChoosedMethod = choosedMethodClass.GetParameters();

            var parametersInput = "";

            foreach (var parameter in parametersFromChoosedMethod)
            {
                Console.WriteLine("Digite um valor: " + parameter.Name + " como parametro");
                var input = Console.ReadLine();

                parametersInput = (parametersInput == "") ? input : "," + input;
            }

            var objectParameter = new object[]{parametersInput};

            var instanceClass = Activator.CreateInstance(typeClass);

            var returnMethodInvoke = choosedMethodClass.Invoke(instanceClass, (parametersInput == "") ? null : objectParameter);

            Console.WriteLine(returnMethodInvoke);

            Console.ReadLine();
        }
    }

    public class Produto
    {
        public string Nome { get; set; }

        public Produto()
        {
            this.Nome = "Produto Novo";
        }

        public static string RetornarNome()
        {
            return "Metodo Estatico";
        }

        public string PublicMethodWithoutParameter()
        {
            return "Metodo Privado Sem Parametro";
        }

        public string PublicMethodWithParameterString(string nome)
        {
            return "Metodo Privado Com Parametro: " + nome;
        }
        public string PublicMethodWithParameterInter(int valor)
        {
            return valor.ToString();
        }

        private string PrivateMethod()
        {
            return "Private";
        }


    }

}
