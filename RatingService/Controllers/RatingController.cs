using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RatingService.Data.Interface;
using RatingService.DTOs.Rating;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Controllers
{
    [ApiController]
    [Route("api/rating")]
    [Produces("application/json", "application/xml")]
    public class RatingController : Controller
    {
        private readonly IRatingRepository ratingRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public RatingController(IRatingRepository ratingRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.ratingRepository = ratingRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<RatingDTO>> GetRatings()
        {
            List<Rating> ratings = ratingRepository.GetRatings();
            if (ratings == null || ratings.Count == 0)
            {
                return NoContent();
            }


            return Ok(ratings);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{ratingId}")]
        public ActionResult<Rating> GetRatingById(Guid ratingId)
        {
            Rating rating = ratingRepository.GetRatingById(ratingId);
            if (rating == null)
            {
                NoContent();
            }
            return Ok(mapper.Map<RatingDTO>(rating));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RatingConfirmationDTO> CreateRating([FromBody] RatingCreationDTO rating)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Rating mappedRating = mapper.Map<Rating>(rating);
                RatingConfirmation confirmationRating = ratingRepository.CreateRating(mappedRating);
                ratingRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetRating", "Rating", new { ratingId = confirmationRating.ratingId });
                return Created(location, mapper.Map<RatingConfirmationDTO>(confirmationRating));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{ratingId}")]
        public IActionResult DeleteRating(Guid ratingId)
        {
            try
            {
                Rating rating = ratingRepository.GetRatingById(ratingId);
                if (rating == null)
                {
                    return NotFound();
                }

                ratingRepository.DeleteRating(ratingId);
                ratingRepository.SaveChanges();
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
        public ActionResult<RatingDTO> UpdateRating(RatingUpdateDTO rating)
        {
            try
            {
                Rating mappedRating = mapper.Map<Rating>(rating);
                var updatedRating = ratingRepository.UpdateRating(mappedRating);
                RatingDTO updatedRatingDTO = mapper.Map<RatingDTO>(updatedRating);
                return Ok(updatedRating);

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
