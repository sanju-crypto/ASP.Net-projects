namespace CrudAPIPractice.Model.Entity
{
	public class Inventory
	{
		public Guid ID { get; set; }
		public required string Location { get; set; }
		public required string Item { get; set; }
		public string? Lot { get; set; }
		public string? LicensePlate { get; set; }

	}
}
