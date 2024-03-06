using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RatingService.Data.Interface;
using RatingService.DTOs.Seller;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Controllers
{
    [ApiController]
    [Route("api/rating/seller")]
    [Produces("application/json", "application/xml")]
    public class SellerController : Controller
    {
        private readonly ISellerRepository sellerRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public SellerController(ISellerRepository sellerRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.sellerRepository = sellerRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<SellerDTO>> GetSellers()
        {
            List<Seller> sellers = sellerRepository.GetSellers();
            if (sellers == null || sellers.Count == 0)
            {
                return NoContent();
            }


            return Ok(sellers);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{sellerId}")]
        public ActionResult<Seller> GetSellerById(Guid sellerId)
        {
            Seller seller = sellerRepository.GetSellerById(sellerId);
            if (seller == null)
            {
                NoContent();
            }
            return Ok(mapper.Map<SellerDTO>(seller));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SellerConfirmationDTO> CreateSeller([FromBody] SellerCreationDTO seller)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Seller mappedSeller = mapper.Map<Seller>(seller);
                SellerConfirmation confirmationSeller = sellerRepository.CreateSeller(mappedSeller);
                sellerRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetSeller", "Seller", new { sellerId = confirmationSeller.sellerId });
                return Created(location, mapper.Map<SellerConfirmationDTO>(confirmationSeller));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{sellerId}")]
        public IActionResult DeleteSeller(Guid sellerId)
        {
            try
            {
                Seller seller = sellerRepository.GetSellerById(sellerId);
                if (seller == null)
                {
                    return NotFound();
                }

                sellerRepository.DeleteSeller(sellerId);
                sellerRepository.SaveChanges();
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
        public ActionResult<SellerDTO> UpdateSeller(SellerUpdateDTO seller)
        {
            try
            {
                Seller mappedSeller = mapper.Map<Seller>(seller);
                var updatedSeller = sellerRepository.UpdateSeller(mappedSeller);
                SellerDTO updatedSellerDTO = mapper.Map<SellerDTO>(updatedSeller);
                return Ok(updatedSeller);

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
