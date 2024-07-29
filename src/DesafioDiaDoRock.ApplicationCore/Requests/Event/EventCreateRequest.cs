using System.ComponentModel.DataAnnotations;

namespace DesafioDiaDoRock.ApplicationCore.Requests.Event
{
    public class EventCreateRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da banda é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da banda deve ter no máximo 100 caracteres.")]
        public string Band { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
        public DateTime Date { get; set; } = DateTime.Now;
        public string NameLocation { get; set; }

        [Required(ErrorMessage = "Selecione um local da lista.")]
        [StringLength(300, ErrorMessage = "Selecione um local da lista.")]
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string UrlImage { get; set; }
    }
}
