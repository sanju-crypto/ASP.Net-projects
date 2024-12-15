namespace CrudAPIPractice.Model
{
	public class UpdateInventoryDto
	{
		public required string Location { get; set; }
		public required string Item { get; set; }
		public string? Lot { get; set; }
		public string? LicensePlate { get; set; }
	}
}
