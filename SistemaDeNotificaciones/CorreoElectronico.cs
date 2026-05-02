class CorreoElectronico : Notificaciones
{
    private string? _correoDestinatario;
    private string? _correoRemitente;

    public CorreoElectronico(string? titulo, string? mensaje, string? destinatario, string? remitente, string? correoDestinatario, string? correoRemitente) : base(titulo, mensaje, destinatario, remitente)
    {
        CorreoDestinatario = correoDestinatario;
        CorreoRemitente = correoRemitente;
    }

    public string? CorreoDestinatario
    {
        get => _correoDestinatario;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El correo no puede estar vacío.", nameof(CorreoDestinatario));
            }
            if (!value.Contains("@") || !value.Contains("."))
            {
                throw new ArgumentException("El formato del correo no es válido.", nameof(CorreoDestinatario));
            }
            _correoDestinatario = value;
        }
    }

    public string? CorreoRemitente
    {
        get => _correoRemitente;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El correo no puede estar vacío.", nameof(CorreoRemitente));
            }          
            _correoRemitente = value;
        }
    }

    protected override void ValidandoNotificacion()
    {
        Console.WriteLine($"[Servidor Correo] Analizando integridad del mensaje para: {Titulo}...");

      
        if (CorreoDestinatario == CorreoRemitente)
        {
            throw new ArgumentException("Error de envío: El correo destinatario no puede ser exactamente el mismo que el correo remitente.");
        }

        Console.WriteLine("[Servidor Correo] Verificación completada. Todo en orden.");
    }




    protected override void EnviandoNotificacion()
    {
       
        Console.WriteLine($"[Servidor] Conectando al servidor de correo para {CorreoDestinatario}...");
        Console.WriteLine($"[Servidor] Autenticando credenciales de {CorreoRemitente}...");
        Console.WriteLine($"[Servidor] Transmitiendo paquete de datos...");
        Console.WriteLine(EstadoNotificacion ? "Estado: Enviado" : "Estado: Enviando...");
        Console.WriteLine($"[Servidor] Notificacion Enviada Con exito");
    
   
    }

    protected override void MostrarNotificacion()
    {
        Console.WriteLine();
        Console.WriteLine("==================================================");
        Console.WriteLine("             NUEVO CORREO ELECTRÓNICO             ");
        Console.WriteLine("==================================================");
        Console.WriteLine($"Asunto:  {Titulo}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"De:      {Remitente} <{CorreoRemitente}>");
        Console.WriteLine($"Para:    {Destinatario} <{CorreoDestinatario}>");
        Console.WriteLine($"Fecha:      {MomentoEnvio}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Mensaje:");
        Console.WriteLine(Mensaje);
        Console.WriteLine("==================================================");
        Console.WriteLine(EstadoNotificacion ? "Estado: Enviado" : "Estado: No enviado");
        Console.WriteLine();
    }
}