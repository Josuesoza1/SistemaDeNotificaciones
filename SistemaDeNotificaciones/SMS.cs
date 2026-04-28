class SMS : Notificaciones
{
    string? _numeroTelefono;
    public SMS(string? titulo, string? mensaje, string? destinatario, string? remitente, string? numeroTelefono) : base(titulo, mensaje, destinatario, remitente)
    {
        NumeroTelefono = numeroTelefono;
    }



    public override void CrearNotificacion(string? mensaje)
    {
       Console.WriteLine($"Creando notificación de SMS con el mensaje: {mensaje}");
    }

    public override void EnviarNotificacion()
    {
        Console.WriteLine($"Enviando SMS a {Destinatario} ({NumeroTelefono}) desde {Remitente} con el mensaje: {Mensaje}");
    }

    public override void MostrarNotificacion()
    {
        Console.WriteLine($"Mostrando notificación de SMS: {Mensaje}");
    }


    public string? NumeroTelefono
    {
        get => _numeroTelefono;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El número de teléfono no puede estar vacío.", nameof(NumeroTelefono));
            }
            _numeroTelefono = value;
        }
    }

   
}

