using CrudAPIPractice.Data;
using CrudAPIPractice.Model;
using CrudAPIPractice.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPIPractice.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InventoryController : ControllerBase
	{
		private readonly ApplicationDBContext dBContext;

		public InventoryController(ApplicationDBContext dBContext)
		{
			this.dBContext = dBContext;
		}
		[HttpGet]
		public IActionResult GetInventories()
		{
			var GetInventory = dBContext.Inventories.ToList();
			return Ok(GetInventory);
		}

		[HttpGet]
		[Route("items/{Item}")]
		public IActionResult GetItems(string Item)
		{
			var items = dBContext.Inventories.FirstOrDefault(x => x.Item == Item);
			if (items == null)
			{
				return NotFound();
			}
			return Ok(items);
		}

		[HttpGet]
		[Route("locations/{Location}")]
		public IActionResult GetLocations(string Location)
		{
			var locations = dBContext.Inventories.FirstOrDefault(x => x.Location == Location);
			if (locations == null)
			{
				return NotFound();
			}
			return Ok(locations);
		}

		[HttpPost]

		public IActionResult PostInventories(PostInventoryDto postInventoryDto)
		{
			var AddInventoryEntity = new Inventory()
			{
				Location = postInventoryDto.Location,
				Item = postInventoryDto.Item,
				Lot = postInventoryDto.Lot,
				LicensePlate = postInventoryDto.LicensePlate
			};
			dBContext.Inventories.Add(AddInventoryEntity);
			dBContext.SaveChanges();     // we need to save the changes in order to reflect in db.
			return Ok(AddInventoryEntity);
		}

		[HttpPut]
		[Route("{ID=Guid}")]

		public IActionResult UpdateItem(Guid ID, UpdateInventoryDto updateInventoryDto)
		{
			var Inventories = dBContext.Inventories.Find(ID);
			if (Inventories == null)
			{
				return NotFound();
			}
			Inventories.Location = updateInventoryDto.Location;
			Inventories.Item = updateInventoryDto.Item;
			Inventories.Lot = updateInventoryDto.Lot;
			Inventories.LicensePlate = updateInventoryDto.LicensePlate;
			dBContext.SaveChanges();
			return Ok(Inventories);
		}

		[HttpDelete]
		[Route("{ID=Guid}")]

		public IActionResult DeleteItem(Guid ID) 
		{
			var deleteTheLine = dBContext.Inventories.Find(ID);
			if (deleteTheLine == null) 
			{ 
			return NotFound();
			}
			dBContext.Inventories.Remove(deleteTheLine);
			dBContext.SaveChanges();
			return Ok(deleteTheLine);  // of I add the variable then it displays that record at last if we add or elese enu beda andre just write return OK();
		}
	}
}
