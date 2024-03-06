using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PurchaseService.Data.Interface;
using PurchaseService.DTOs.Delivery;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;

namespace PurchaseService.Controllers
{
    [ApiController]
    [Route("api/purchase/delivery")]
    [Produces("application/json", "application/xml")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryRepository deliveryRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public DeliveryController(IDeliveryRepository deliveryRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.deliveryRepository = deliveryRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DeliveryDTO>> GetDeliverys()
        {
            List<Delivery> deliverys = deliveryRepository.GetDeliverys();
            if (deliverys == null || deliverys.Count == 0)
            {
                return NoContent();
            }


            return Ok(deliverys);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{deliveryId}")]
        public ActionResult<Delivery> GetDeliveryById(Guid deliveryId)
        {
            Delivery delivery = deliveryRepository.GetDeliveryById(deliveryId);
            if (delivery == null)
            {
                NoContent();
            }
            return Ok(mapper.Map<DeliveryDTO>(delivery));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeliveryConfirmationDTO> CreateDelivery([FromBody] DeliveryCreationDTO delivery)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Delivery mappedDelivery = mapper.Map<Delivery>(delivery);
                DeliveryConfirmation confirmationDelivery = deliveryRepository.CreateDelivery(mappedDelivery);
                deliveryRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetDelivery", "Delivery", new { deliveryId = confirmationDelivery.deliveryId });
                return Created(location, mapper.Map<DeliveryConfirmationDTO>(confirmationDelivery));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{deliveryId}")]
        public IActionResult DeleteDelivery(Guid deliveryId)
        {
            try
            {
                Delivery delivery = deliveryRepository.GetDeliveryById(deliveryId);
                if (delivery == null)
                {
                    return NotFound();
                }

                deliveryRepository.DeleteDelivery(deliveryId);
                deliveryRepository.SaveChanges();
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
        public ActionResult<DeliveryDTO> UpdateDelivery(DeliveryUpdateDTO delivery)
        {
            try
            {
                Delivery mappedDelivery = mapper.Map<Delivery>(delivery);
                var updatedDelivery = deliveryRepository.UpdateDelivery(mappedDelivery);
                DeliveryDTO updatedDeliveryDTO = mapper.Map<DeliveryDTO>(updatedDelivery);
                return Ok(updatedDelivery);

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
