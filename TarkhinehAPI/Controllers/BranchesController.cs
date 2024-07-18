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
    public class BranchesController : ControllerBase
    {
        private readonly ITblBranchRepository _tblBranchRepository;

        public BranchesController(ITblBranchRepository tblBranchRepository)
        {
            _tblBranchRepository = tblBranchRepository;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblBranch>>> GetBranchs()
        {
            try
            {
                IEnumerable<TblBranch> branches = await _tblBranchRepository.GetAllBranches();
                if (branches == null)
                {
                    return NotFound();
                }
                return Ok(branches);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblBranch>> GetBranch(int id)
        {
            var branch = await _tblBranchRepository.FindBranch(id);
            try
            {
                if (branch == null)
                {
                    return NotFound();
                }
                return Ok(branch);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, TblBranch branch)
        {
            if (id !=  branch.BranchId)
            {
                return BadRequest();
            }

            branch.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblBranchRepository.UpdateBranch(branch);

            try
            {
                await _tblBranchRepository.SaveDb();
                return Ok(branch);
            }
            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await BranchExists(id);
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

        // POST: api/Branches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblBranch>> PostBranch(TblBranch branch)
        {
            branch.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newBranch = await _tblBranchRepository.CreateBranch(branch);
                if (newBranch != null)
                {
                    await _tblBranchRepository.SaveDb();
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

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblBranch(int id)
        {
            var entity = await _tblBranchRepository.FindBranch(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblBranchRepository.DeleteBranch(id);
                await _tblBranchRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> BranchExists(int id)
        {
            var entity = await _tblBranchRepository.FindBranch(id);
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
