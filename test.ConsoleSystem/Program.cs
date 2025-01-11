using test.ConsoleSystem.Services;

class Program
{
    private static readonly BancoService _bancoService = new BancoService();
    
    static async Task Main(string[] args)
    {
        while (true)
        {
            string titulo = "--- Menú de Bancos ---";
            string separador = new string('=', 30);
            int anchoConsola = Console.WindowWidth;
            
            Console.WriteLine(separador.PadLeft((anchoConsola + separador.Length) / 2));
            Console.WriteLine(titulo.PadLeft((anchoConsola + titulo.Length) / 2));
            Console.WriteLine(separador.PadLeft((anchoConsola + separador.Length) / 2));
            Console.WriteLine();
            
            string[] opciones =
            {
                "1. Listar Bancos disponibles",
                "2. Salir"
            };

            foreach (string opcion in opciones)
            {
                Console.WriteLine(opcion.PadLeft((anchoConsola + opcion.Length) / 2));
            }

            Console.WriteLine();
            string prompt = "Selecciona una opción: ";
            Console.Write(prompt.PadLeft((anchoConsola + prompt.Length) / 2));
            
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListBancoAsync();
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
    
    private static async Task ListBancoAsync()
    {
        try
        {
            var bancos = await _bancoService.GetBancos();
            if (bancos.Count == 0)
            {
                Console.WriteLine("No hay bancos registrados.");
                return;
            }
            
            Console.WriteLine("\n--- Lista de Bancos ---");
            Console.WriteLine($"{"ID Banco",-5} {"Nombre",-20} {"SWIFT",-30} {"Pais",-15} {"Sucursal",-30} {"Teléfono",-15}");
            Console.WriteLine(new string('-', 120));
            
            foreach (var banco in bancos)
            {
                Console.WriteLine($"{banco.Id,-5} {banco.nombre,-20} {banco.swift,-30} {banco.pais,-15} {banco.sucursal,-30} {banco.telefono,-15}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}