using System;
using System.ComponentModel.DataAnnotations;

namespace DAOEntityFramework.EntityModels
{
	public class ToDo
	{
        [Required]
		public int Id { get; set; }
	 
	    [Required]
		public string Name { get; set; } 

		[StringLength(500)]
		public string Description { get; set; } 

		public DateTime DueDate { get; set; } 

		[Required]
		public bool Status { get; set; } 
	}
}
