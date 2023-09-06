using System.ComponentModel.DataAnnotations;

namespace NossoERP.WebApi.Nuvem.Clinica.Database
{
    public class cid
    {
        public int id { get; set; }
        [Required]
        public string descricao { get; set; }
        [Required, MaxLength(20)]
        public string codigo { get; set; }
        /// <summary>
        /// referencia de onde copiou os dados
        /// </summary>
        public int? id_externo { get; set; }
    }
}
