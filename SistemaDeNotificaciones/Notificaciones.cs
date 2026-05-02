using System.Globalization;

abstract class Notificaciones
{

    private string? _titulo;
    private string? _mensaje;
    private string? _destinatario;
    private string? _remitente;

    protected Notificaciones(string? titulo, string? mensaje, string? destinatario, string? remitente)
    {
        Titulo = titulo;
        Mensaje = mensaje;
        Destinatario = destinatario;
        Remitente = remitente;
    }

    public string? Titulo
    {
        get => _titulo;
        set
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
        set
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
                throw new ArgumentException("El destinatario no puede estar vacío.", nameof(Destinatario));
            }
            _destinatario = value;
        }
    }
    public string? Remitente
    {
        get => _remitente;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El remitente no puede estar vacío.", nameof(Remitente));
            }
            _remitente = value;
        }
    }

    public abstract void CrearNotificacion(string? mensaje);
    public abstract void EnviarNotificacion();
    public abstract void MostrarNotificacion();

   /* public abstract void GuardarNotificacion();
    public abstract void EliminarNotificacion();

    Estoy dudando si es necesario o no, porque la aplicacion es de notificar solamente

    */

}

