class CorreoElectronico : Notificaciones
{
    private string? _correo;
   
    public CorreoElectronico(string? titulo, string? mensaje, string? destinatario, string? remitente, string? correo) : base(titulo, mensaje, destinatario, remitente)
    {
        Correo = correo;
    }







    public string? Correo
    {
        get => _correo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El correo no puede estar vacío.", nameof(Correo));
            }
            _correo = value;
        }
    }

    public override void CrearNotificacion(string? mensaje)
    {
        Console.WriteLine($"Creando notificación de correo electrónico con el mensaje: {mensaje}");
    }

    public override void EnviarNotificacion()
    {
        Console.WriteLine($"Enviando correo electrónico a {Destinatario} ({Correo}) desde {Remitente} con el mensaje: {Mensaje}");
    }

    public override void MostrarNotificacion()
    {
        Console.WriteLine($"Notificación de correo electrónico:\nDe: {Remitente}\nPara: {Destinatario}\nCorreo: {Correo}\nAsunto: {Titulo}\nMensaje: {Mensaje}");
    }
}