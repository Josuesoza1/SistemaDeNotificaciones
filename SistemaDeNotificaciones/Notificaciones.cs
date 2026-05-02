using System.Globalization;

abstract class Notificaciones
{

    private string? _titulo;
    private string? _mensaje;
    private string? _destinatario;
    private string? _remitente;
    private DateTime _momentoEnvio;

    public bool EstadoNotificacion { get; protected set; }

    protected Notificaciones(string? titulo, string? mensaje, string? destinatario, string? remitente)
    {
        Titulo = titulo;
        Mensaje = mensaje;
        Destinatario = destinatario;
        Remitente = remitente;
        EstadoNotificacion = false;

    }
    public DateTime MomentoEnvio
    {
        get => _momentoEnvio; protected set => _momentoEnvio = value;
    }
    public string? Titulo
    {
        get => _titulo;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El título no puede estar vacío.", nameof(Titulo));
            }
            _titulo = value;
        }
    }
    public string? Mensaje
    {
        get => _mensaje;
        protected set
        {
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El mensaje no puede estar vacío.", nameof(Mensaje));
                }
                _mensaje = value;
            }

        }
    }

    public string? Destinatario
    {
        get => _destinatario;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El nombre del destinatario no puede estar vacío.", nameof(Destinatario));
            }
            _destinatario = value;
        }
    }
    public string? Remitente
    {
        get => _remitente;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El nombre del remitente no puede estar vacío.", nameof(Remitente));
            }
            _remitente = value;
        }
    }

    public void ProcesoNotificacion()
    {
        try
        {
            ValidandoNotificacion();
            EnviandoNotificacion();
            FinalizandoNotificacion();
            MostrarNotificacion(); 
        }
        catch (Exception ex)
        {
           
            Console.WriteLine($"\n[ERROR EN EL PROCESO]: {ex.Message}");
        }


    }

    protected abstract void ValidandoNotificacion();
    protected abstract void EnviandoNotificacion();
    protected virtual void FinalizandoNotificacion()
    {
        MomentoEnvio = DateTime.Now;
        EstadoNotificacion = true;
        Console.WriteLine($"[Sistema] Envío finalizado a las {MomentoEnvio:HH:mm:ss}.");
    }

    protected virtual void MostrarNotificacion()
    {
    }


}

