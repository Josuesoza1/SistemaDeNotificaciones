
int opc = 0;
while (true)
{
    Console.Clear();
    Console.WriteLine("Pruebas de validacion");
    Console.WriteLine("1. Prueba con correo (Buen estado)");
    Console.WriteLine("2. Prueba con SMS (BUEN ESTADO");
    Console.WriteLine("3. Prueba con correo (Correo mal escrito)");
    Console.WriteLine("4. Prueba con SMS (Numero de menos de 8 digitos) ");
    Console.WriteLine("5. Salir");


    opc = int.Parse(Console.ReadLine());
    try
    {
        switch (opc)
        {


            case 1:
                Console.Clear();
                CorreoElectronico correoExitoso = new CorreoElectronico("Bienvenida al Sistema", "Gracias por registrarte en nuestra plataforma de servicios digitales.", "Fredy Garcia", "Soporte Técnico", "@.fredygarciagmailcom", "soporte@empresa.com");
                correoExitoso.ProcesoNotificacion();
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.ReadLine();
                break;
            case 2:
                Console.Clear();
                SMS smsExitoso = new SMS("Alerta de Seguridad", "Su código de verificación a Cariñosas.net es 3231. No lo comparta.", "Aydan Navarro", "Cariñosas.net", "86971660");
                smsExitoso.ProcesoNotificacion();
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.ReadLine();
                break;
            case 3:
                Console.Clear();
                CorreoElectronico correoLogicaInvalida = new CorreoElectronico("Bucle Infinito", "Mensaje de prueba a mí mismo", "Juan", "Juan", "juangmailcom", "juan@gmail.com");
                correoLogicaInvalida.ProcesoNotificacion();
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.ReadLine();
                break;
            case 4:
                Console.Clear();
                SMS smsInvalido = new SMS("Fallo", "Este mensaje no debería enviarse.", "Usuario", "Sistema", "1234");
                smsInvalido.ProcesoNotificacion();
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.ReadLine();
                break;
            case 5:
                break;
            default:
                Console.WriteLine("Opcion Invalida");
                break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"[ERROR DE CREACIÓN]: {ex.Message}");
        Console.WriteLine("Precione cualquier tecla para regresar");
        Console.ReadLine();
    }

}
