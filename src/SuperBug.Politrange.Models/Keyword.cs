namespace SuperBug.Politrange.Models
{
	public class Keyword
	{
		public int KeywordId { get; set; }
		public string Name { get; set; }
	    public int PersonId { get; set; }
		public Person Person { get; set; }
	}
}