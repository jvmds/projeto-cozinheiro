namespace ProjetoCozinheiro.Componentes;

public static class Start
{
    public const string TEXTO_START = """
                                                  _____  ______ _____
                                                 |  __ \|  ____|_   _|
                                                 | |__) | |__    | |
                                                 |  _  /|  __|   | |
                                                 | | \ \| |____ _| |_
                                                 |_|__\_\______|_____|
                                                 |  __ \   /\
                                                 | |  | | /  \
                                                 | |  | |/ /\ \
                                                 | |__| / ____ \
                                                 |_____/_/___ \_\________ _   _ _    _
                                                  / ____/ __ \___  /_   _| \ | | |  | |   /\
                                                 | |   | |  | | / /  | | |  \| | |__| |  /  \
                                                 | |   | |  | |/ /   | | | . ` |  __  | / /\ \
                                                 | |___| |__| / /__ _| |_| |\  | |  | |/ ____ \
                                                  \_____\____/_____|_____|_| \_|_|  |_/_/    \_\
                                       """;
    
    public static void Iniciar()
    {
        foreach (var linha in TEXTO_START.Split('\n'))
        {
            Console.WriteLine(linha);
            Thread.Sleep(100);
        }
      
        Console.WriteLine('\n');
        var visivel = false;
        while (!Console.KeyAvailable)
        {
            visivel = !visivel;
            Console.SetCursorPosition(0, Console.CursorTop);
            if (visivel)
            {
                Console.Write("          <<< Digite qualquer tecla para iniciar! >>>");
            }
            else
            {
                Console.Write(new string(' ', 53));
            }
          
            Thread.Sleep(700);
        }

        Console.ReadKey(true);
        Console.Clear();
    }
}