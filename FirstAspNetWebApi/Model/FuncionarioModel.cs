using System.ComponentModel.DataAnnotations;

namespace FirstAspNetWebApi.Model
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int age { get; set;}
        public string? photo { get; set;}
    }
}
