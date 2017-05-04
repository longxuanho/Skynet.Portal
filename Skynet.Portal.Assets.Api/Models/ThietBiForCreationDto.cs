using System.ComponentModel.DataAnnotations;

namespace Skynet.Portal.Assets.Api.Models
{
    public class ThietBiForCreationDto : BookForManipulationDto
    {
        [Required]
        [MaxLength(50)]
        public string MaThietBi { get; set; }
    }
}
