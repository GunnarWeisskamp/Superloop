using System;

namespace APINUnitTests.Model
{
	public class ToDo
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime DueDate { get; set; }

		public bool Status { get; set; }
	}
}
