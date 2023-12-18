#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntegralService146.Models;
using System.Linq;

namespace IntegralService146.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly QuestionContext _context;

        public QuestionController(QuestionContext context)
        {
            _context = context;
        }

        // Post: api/question
        [HttpGet]
        public async Task<ActionResult<Question>> GetQuestions(int questionCount)
        {
            var randomNquestions = await (_context.Questions
                .Select(x => new
                {
                    QuestionId = x.QuestionID,
                    QuestionText = x.QuestionText,
                    Answers = new string[] { x.Answer1, x.Answer2, x.Answer3, x.Answer4 },
                    RightAnswer = x.RightAnswer,
                })
                .OrderBy(y => Guid.NewGuid())
                .Take(questionCount)
                ).ToListAsync();

            return Ok(randomNquestions);
        }

    }
}
