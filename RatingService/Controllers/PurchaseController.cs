using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RatingService.Data.Interface;
using RatingService.DTOs.Purchase;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Controllers
{
    [ApiController]
    [Route("api/rating/purchase")]
    [Produces("application/json", "application/xml")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository purchaseRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public PurchaseController(IPurchaseRepository purchaseRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.purchaseRepository = purchaseRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PurchaseDTO>> GetPurchases()
        {
            List<Purchase> purchases = purchaseRepository.GetPurchases();
            if (purchases == null || purchases.Count == 0)
            {
                return NoContent();
            }


            return Ok(purchases);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{purchaseId}")]
        public ActionResult<Purchase> GetPurchaseById(Guid purchaseId)
        {
            Purchase purchase = purchaseRepository.GetPurchaseById(purchaseId);
            if (purchase == null)
            {
                NoContent();
            }
            return Ok(mapper.Map<PurchaseDTO>(purchase));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PurchaseConfirmationDTO> CreatePurchase([FromBody] PurchaseCreationDTO purchase)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Purchase mappedPurchase = mapper.Map<Purchase>(purchase);
                PurchaseConfirmation confirmationPurchase = purchaseRepository.CreatePurchase(mappedPurchase);
                purchaseRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetPurchase", "Purchase", new { purchaseId = confirmationPurchase.purchaseId });
                return Created(location, mapper.Map<PurchaseConfirmationDTO>(confirmationPurchase));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{purchaseId}")]
        public IActionResult DeletePurchase(Guid purchaseId)
        {
            try
            {
                Purchase purchase = purchaseRepository.GetPurchaseById(purchaseId);
                if (purchase == null)
                {
                    return NotFound();
                }

                purchaseRepository.DeletePurchase(purchaseId);
                purchaseRepository.SaveChanges();
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
        public ActionResult<PurchaseDTO> UpdatePurchase(PurchaseUpdateDTO purchase)
        {
            try
            {
                Purchase mappedPurchase = mapper.Map<Purchase>(purchase);
                var updatedPurchase = purchaseRepository.UpdatePurchase(mappedPurchase);
                PurchaseDTO updatedPurchaseDTO = mapper.Map<PurchaseDTO>(updatedPurchase);
                return Ok(updatedPurchase);

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
