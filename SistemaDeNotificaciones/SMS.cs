class SMS : Notificaciones
{
   
    string? _numeroTelefono;
    public SMS(string? titulo, string? mensaje, string? destinatario, string? remitente, string? numeroTelefono) : base(titulo, mensaje, destinatario, remitente)
    {
        NumeroTelefono = numeroTelefono;
    }


    /// <summary>
    /// Metodo para crear la notificacion
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    protected override void ValidandoNotificacion()
    {
        if (Mensaje.Length > 150)
        {
            throw new ArgumentException("Excede el limite de caracteres", nameof(Mensaje));
        }
        Console.WriteLine($"Creando notificación de SMS para el numero: {NumeroTelefono}");
        Console.WriteLine($"Mensaje: {Mensaje}");
    }
    /// <summary>
    /// Metodo para generar y enviar la notificacion indicando de quien es y para quien esta dirigido
    /// </summary>
    protected override void EnviandoNotificacion()
    {
        Console.WriteLine($"[Red Telefónica] Conectando con la antena más cercana...");
        Console.WriteLine($"[Red Telefónica] Transmitiendo paquete SMS al número +505 {NumeroTelefono}...");
        Console.WriteLine(EstadoNotificacion ? "Estado: Enviado" : "Estado: Enviando...");
    }

    protected override void MostrarNotificacion()
    {
        MomentoEnvio = DateTime.Now;
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Para: {Destinatario} +505 {NumeroTelefono}");
        Console.WriteLine($"De: {Remitente} ");
        Console.WriteLine($"Fecha {MomentoEnvio}");
        Console.WriteLine($"Mensaje: {Mensaje}");
        Console.WriteLine("--------------------------");
        Console.WriteLine(EstadoNotificacion ? "Estado: Enviado" : "Estado: No Enviado");
       
    }

    public string? NumeroTelefono
    {
        get => _numeroTelefono;
       private set
        {

            if (string.IsNullOrWhiteSpace(value))//Valida que NumeroTelefono no este vacio
            {
                throw new ArgumentException("El número de teléfono no puede estar vacío.", nameof(NumeroTelefono));
            }
            if (value.Length != 8)//Luego valida que el numero sea igual a 8 digitos que ese es la cantidad de digitos para el numero de telefono de Nicaragua
            {
                throw new ArgumentException("El número de telefono debe contener 8 digitos. ", nameof(NumeroTelefono));
            }
            foreach (char c in value)//Comprobacion para verificar si todos los numeros ingresados son digitos
            {
                if (!char.IsDigit(c))
                {
                    throw new ArgumentException("El número de teléfono solo debe contener números.", nameof(NumeroTelefono));
                }
            }
            char var = value[0];//Se crea un arreglo caracter desde la posicion principal
            if (!"578".Contains(var))//para validar si contiene los prefijos nacionales que son 578. Sin todas estas validaciones el numero de telefono nunca será valido
            {
                throw new ArgumentException("Error en el prefijo numero de telefono debe iniciar con el prefijo 5,7 u 8 ");
            }
            _numeroTelefono = value;
        }
    }


}

