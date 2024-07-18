using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Contracts;

namespace TarkhinehAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly ITblAgentRepository _tblAgentRepository;

        public AgentsController(ITblAgentRepository tblAgentRepository)
        {
            _tblAgentRepository = tblAgentRepository;
        }

        // GET: api/Agents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAgent>>> GetAgents()
        {
            try
            {
                IEnumerable<TblAgent> agents = await _tblAgentRepository.GetAllAgent();
                if (agents == null)
                {
                    return NotFound();
                }
                return Ok(agents);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Agents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAgent>> GetAgent(int id)
        {
            var agent = await _tblAgentRepository.FindAgent(id);
            try
            {
                if (agent == null)
                {
                    return NotFound();
                }
                return Ok(agent);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Agents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgent(int id, TblAgent agent)
        {
            if (id != agent.AgentId)
            {
                return BadRequest();
            }

            agent.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblAgentRepository.UpdateAgent(agent);

            try
            {
                await _tblAgentRepository.SaveDb();
                return Ok(agent);
            }
            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await AgentExists(id);
                if (!itemExist)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // POST: api/Agents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAgent>> PostAgent(TblAgent agent)
        {
            agent.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newAgent = await _tblAgentRepository.CreateAgent(agent);
                if (newAgent != null)
                {
                    await _tblAgentRepository.SaveDb();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Agents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgent(int id)
        {
            var entity = await _tblAgentRepository.FindAgent(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblAgentRepository.DeleteAgent(id);
                await _tblAgentRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> AgentExists(int id)
        {
            var entity = await _tblAgentRepository.FindAgent(id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
