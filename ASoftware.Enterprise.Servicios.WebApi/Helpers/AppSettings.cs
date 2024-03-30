namespace ASoftware.Enterprise.Servicios.WebApi.Helpers {

    /// <summary>
    /// Clase de formato de AppSettings
    /// </summary>
    public class AppSettings {
        /// <summary>
        /// Propiedad para configuracion de CORS
        /// </summary>
        public required string OriginCors { get; set; }
        /// <summary>
        /// Propiedad para obtene el Secret de appsettings
        /// </summary>
        public required string Secret { get; set; }
        /// <summary>
        /// Emisor para los Tokens
        /// </summary>
        public required string Issuer { get; set; }
        /// <summary>
        /// Audience para los Tokens
        /// </summary>
        public required string Audience { get; set; }
    }
}
