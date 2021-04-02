
namespace API.ModelAPI
{
	public class ResultAPI : IResultAPI
	{
		public ResultAPI()
		{
		}
		public string EndMessage { get; set; }
		public bool IsError { get; set; }
	}
}
