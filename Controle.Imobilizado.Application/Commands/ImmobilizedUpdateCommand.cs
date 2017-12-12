﻿namespace Controle.Imobilizado.Application.Models
{
    /// <summary>
    /// Command update Immobilized
    /// </summary>
    public class ImmobilizedUpdateCommand
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public bool Active { get; set; }
        public string Serial { get; set; }
    }
}