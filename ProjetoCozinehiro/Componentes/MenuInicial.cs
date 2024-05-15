using System;
using System.Threading;

namespace CozinheiroRpg.Componentes;


public class MenuInicial
{
    public bool Execultar()
    {
      var texto = """
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

      foreach (var linha in texto.Split('\n'))
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
      return true;
    }
}