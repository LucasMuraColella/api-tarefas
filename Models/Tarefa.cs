using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_tarefas.Models
{
    [Table("Tarefas")]
    public class Tarefa
    {
        [Key]
        public int id_tarefa { get; set; }

        [Display(Name = "Descrição da tarefa")]
        [Required]
        public string descricao_tarefa { get; set; }

        [Display(Name = "Data prevista de conclusão da tarefa")]
        [Required]
        public DateTime data_prevista { get; set; }

        [Display(Name = "Data de conclusão da tarefa")]
        [Required]
        public DateTime data_conclusao { get; set; }

        //cria um campo de chave estrangeira para relacionar com a tabela
        //usuario através do atributo id_usuario
        [ForeignKey("fk_usuario")]
        [Display(Name = "Id do usuário")]
        [Required]
        public int fk_usuario { get; set; }

        //Valida a relação de 1 tarefa com 1 usuário (recurso de navegação)
        public Usuario usuario { get; set; }
    }
}
