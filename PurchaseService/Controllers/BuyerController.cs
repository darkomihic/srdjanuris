using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PurchaseService.DTOs.Buyer;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;
using PurchaseService.Data.Interface;

namespace PurchaseService.Controllers
{
    [ApiController]
    [Route("api/purchase/buyer")]
    [Produces("application/json", "application/xml")]
    public class BuyerController : Controller
    {
        private readonly IBuyerRepository buyerRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public BuyerController(IBuyerRepository buyerRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.buyerRepository = buyerRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<BuyerDTO>> GetBuyers()
        {
            List<Buyer> buyers = buyerRepository.GetBuyers();
            if (buyers == null || buyers.Count == 0)
            {
                return NoContent();
            }


            return Ok(buyers);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{buyerId}")]
        public ActionResult<Buyer> GetBuyerById(Guid buyerId)
        {
            Buyer buyer = buyerRepository.GetBuyerById(buyerId);
            if (buyer == null)
            {
                NoContent();
            }
            return Ok(mapper.Map<BuyerDTO>(buyer));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BuyerConfirmationDTO> CreateBuyer([FromBody] BuyerCreationDTO buyer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Buyer mappedBuyer = mapper.Map<Buyer>(buyer);
                BuyerConfirmation confirmationBuyer = buyerRepository.CreateBuyer(mappedBuyer);
                buyerRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetBuyer", "Buyer", new { buyerId = confirmationBuyer.buyerId });
                return Created(location, mapper.Map<BuyerConfirmationDTO>(confirmationBuyer));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{buyerId}")]
        public IActionResult DeleteBuyer(Guid buyerId)
        {
            try
            {
                Buyer buyer = buyerRepository.GetBuyerById(buyerId);
                if (buyer == null)
                {
                    return NotFound();
                }

                buyerRepository.DeleteBuyer(buyerId);
                buyerRepository.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent, "Brisanje je uspesno.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BuyerDTO> UpdateBuyer(BuyerUpdateDTO buyer)
        {
            try
            {
                Buyer mappedBuyer = mapper.Map<Buyer>(buyer);
                var updatedBuyer = buyerRepository.UpdateBuyer(mappedBuyer);
                BuyerDTO updatedBuyerDTO = mapper.Map<BuyerDTO>(updatedBuyer);
                return Ok(updatedBuyer);

            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
