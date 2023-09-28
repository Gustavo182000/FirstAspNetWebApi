using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAspNetWebApi.Model
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }

        [NotMapped]
        public IFormFile? photo { get; set; }
        public string? photoPath { get; set; }

    }
}
