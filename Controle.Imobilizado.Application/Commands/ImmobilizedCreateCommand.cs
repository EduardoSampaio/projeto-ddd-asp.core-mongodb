namespace Controle.Imobilizado.Application.Models
{
    /// <summary>
    /// Command Create Immobilized
    /// </summary>
    public class ImmobilizedCreateCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public bool Active { get; set; }
        public string Serial { get; set; }
    }
}