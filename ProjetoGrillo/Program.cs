using System;



namespace ProjetoGrillo
{
    class Program
    {
        private static Banco banco = new Banco();
        private static Conta contaDestino;

        static Program()
        {
            var cidade = new Cidade("Jundiai", "SP");
            var endereco = new Endereco("Rua Gen. Osírio", "centro", "13219-000", 100, cidade);
            var cliente = new Cliente("Grillo", "12133213", new DateTime(1983, 7, 2), endereco);

            contaDestino = banco.AbrirConta(cliente);
        }
        private static void Main(string[] args)
        {
            try
            {
                var cidade = new Cidade("Jundiai", "SP");
                var endereco = new Endereco("Rua Uncila Lorencini", "Terra da Uva", "13214-600", 161, cidade);
                var cliente = new Cliente("Ricardo", "564656", new DateTime(1565, 7, 2), endereco);

                var contaRicardo = banco.AbrirConta(cliente);
                contaRicardo.Depositar(2500);
                contaRicardo.Sacar(350);
                contaRicardo.TirarEstrato();
                contaRicardo.Transferir(1, 1, 1200);
                contaRicardo.TirarEstrato();
                contaDestino.TirarEstrato();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ResetColor();
            Console.WriteLine(string.Empty);
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
